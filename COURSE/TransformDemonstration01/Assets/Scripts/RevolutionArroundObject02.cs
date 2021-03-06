/**
 * @file RevolutionArroundObject02.cs
 * @author NDark
 * 
 * Rotate value by FPS
 * 
 * @date 20130712 . file started.
 * 
 * 
 */
using UnityEngine;
using System.Collections;

public class RevolutionArroundObject02 : MonoBehaviour 
{
	public float m_RotateSpeed = 30.0f ;
	public GameObject m_CenterTarget = null ;
	
	// Use this for initialization
	void Start () 
	{
		if( null == m_CenterTarget )
		{
			IntializeCenterTarget() ;
		}
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( null == m_CenterTarget )
			return ;
		
		Quaternion rotateByYAxisThisFrame = Quaternion.identity ;
		rotateByYAxisThisFrame = Quaternion.AngleAxis( m_RotateSpeed * Time.deltaTime , Vector3.up ) ;
		
		Vector3 centerToMe = this.gameObject.transform.position - m_CenterTarget.transform.position ;
				
		Vector3 rotateCenterToMe = rotateByYAxisThisFrame * centerToMe ;
		
		this.transform.position = m_CenterTarget.transform.position + rotateCenterToMe ;
	}
	
	private void IntializeCenterTarget()
	{
		m_CenterTarget = GameObject.Find( "Crab" ) ;
		if( null == m_CenterTarget )
		{
			Debug.LogError( "RevolutionArroundObject02::IntializeCenterTarget() null == m_CenterTarget" ) ;
		}
		else
		{
			Debug.Log( "RevolutionArroundObject02::IntializeCenterTarget() end." ) ;
		}
	}
}
