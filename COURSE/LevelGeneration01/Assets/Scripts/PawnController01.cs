/*
@file LevelGeneration01.cs
@author NDark
@date 20130616 . file created.
@date 20130721 by NDark
. add comment.
. remove class member m_Boundary.
 */
using UnityEngine;
using System.Collections;

public class PawnController01 : MonoBehaviour 
{
	public enum MoveState
	{
		Steady = 0,
		InMove ,
	}
	
	public MoveState m_MoveState = MoveState.Steady ;
	
	public Vector3 m_TargetPos = Vector3.zero ; // 目前下一個目標位置
	public float m_DistanceOfABlock = 1.25f ; // 棋盤上每個格子的間距
	public float m_ToTargetThreashold = 0.01f ; // 如何判定已經抵達
	public float m_MoveSpeed = 2.1f ;// 移動(內差)速度
	
	public Vector3 m_RightABlock = Vector3.zero ;
	public Vector3 m_LeftABlock = Vector3.zero ;
	public Vector3 m_UpABlock = Vector3.zero ;
	public Vector3 m_DownABlock = Vector3.zero ;
	
	// Use this for initialization
	void Start () 
	{
		m_RightABlock = new Vector3( m_DistanceOfABlock , 0 , 0 ) ;
		m_LeftABlock = new Vector3( -1 * m_DistanceOfABlock , 0 , 0 ) ;
		m_UpABlock = new Vector3( 0 , 0 , m_DistanceOfABlock ) ;
		m_DownABlock = new Vector3( 0 , 0 , -1 * m_DistanceOfABlock ) ;		
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch( m_MoveState )
		{
		case MoveState.Steady :
			CheckMove() ;
			break ;
		case MoveState.InMove :
			KeepMoving() ;
			break ;			
		}
	}
	
	private void CheckMove()
	{
		Vector3 targetPos = Vector3.zero ;
		
		// get up down left right arrow value
		float leftright = Input.GetAxis( "Horizontal" ) ;
		float updown = Input.GetAxis( "Vertical" ) ;		
		// Debug.Log( "PawnController01:CheckMove() leftright=" + leftright ) ;
		
		// right
		Transform thisTransform = this.gameObject.transform ;
		if( leftright > 0 )
		{
			targetPos = thisTransform.position + m_RightABlock ;
		}
		
		// left
		else if( leftright < 0 )
		{
			targetPos = thisTransform.position + m_LeftABlock ;
		}
		
		// up
		else if( updown > 0 )
		{
			targetPos = thisTransform.position + m_UpABlock ;
		}	
		
		// down
		else if( updown < 0 )
		{
			targetPos = thisTransform.position + m_DownABlock ;
		}

		// nothing
		else
		{
			return ;
		}
		
		// set target and actually move
		m_TargetPos = targetPos ;
		m_MoveState = MoveState.InMove ;
		
	}
	
	private void KeepMoving()
	{
		Transform thisTransform = this.gameObject.transform ;
		Vector3 positionNow = thisTransform.position ;
		
		Vector3 distanceVecNow = m_TargetPos - positionNow ;
		if( distanceVecNow.magnitude < m_ToTargetThreashold ) 
		{
			// 立即抵達
			thisTransform.position = m_TargetPos ;
			m_MoveState = MoveState.Steady ;// 切換狀態
		}
		else
		{
			// 繼續內差
			Vector3 nextPosition = Vector3.Lerp( positionNow , 
												 m_TargetPos , 
												 m_MoveSpeed * Time.deltaTime ) ;
			thisTransform.position = nextPosition ;
		}
	}
}
