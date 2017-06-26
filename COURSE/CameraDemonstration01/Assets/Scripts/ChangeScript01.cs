/*
 * @file ChangeScript01.cs
 * @author NDark
 * @date 20130601 . file started.
 * @date 20130712 
 * . rename class member m_TargetObject to m_MainCharacterObj.
 * . rename class member m_TestObject to m_CameraObject.
 * . add code of change compoent by string.
 */
using UnityEngine;
using System.Collections;

public class ChangeScript01 : MonoBehaviour 
{
	public float m_DistanceThreashold = 4.0f ;
	public GameObject m_MainCharacterObj = null ; // main character
	public GameObject m_CameraObject = null ;
	public bool m_Valid = true ; // only add once

	// Use this for initialization
	void Start () 
	{
		// 沒設定才要初始化
		if( null == m_CameraObject )
			InitializeCameraPtr() ;			
		
		if( null == m_MainCharacterObj )
			InitializeMainCharacter() ;			
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( true == m_Valid )
		{
			CheckAndChangeScriptByType() ;
			// or you can use 
			// CheckAndChangeScriptByString() ;
		}
	
	}
	
	private void CheckAndChangeScriptByType()
	{
		if( null == m_MainCharacterObj || null == m_CameraObject )
			return ;
		
		Vector3 distanceVec = m_MainCharacterObj.transform.position - m_CameraObject.transform.position ;
		if( distanceVec.magnitude < m_DistanceThreashold )
		{
			// 抵達
			CameraController_CameraRoutes02 scriptPtr = m_MainCharacterObj.GetComponent<CameraController_CameraRoutes02>() ;
			if( null == scriptPtr )
			{
				Debug.LogError( "ChangeScript01:CheckAndChangeScriptByType() null == scriptPtr" ) ;
			}
			else
			{
				Component.Destroy( scriptPtr ) ;
				m_MainCharacterObj.AddComponent<CameraController_RotateAroundTarget01>() ;
				
				m_Valid = false ;// only add once
			}
		}
	}
	
	private void CheckAndChangeScriptByString()
	{
		if( null == m_MainCharacterObj || null == m_CameraObject )
			return ;
		
		Vector3 distanceVec = m_MainCharacterObj.transform.position - m_CameraObject.transform.position ;
		if( distanceVec.magnitude < m_DistanceThreashold )
		{
			// 抵達
			Component scriptPtr = m_MainCharacterObj.GetComponent("CameraController_CameraRoutes02") ;
			if( null == scriptPtr )
			{
				Debug.LogError( "ChangeScript01:CheckAndChangeScriptByString() null == scriptPtr" ) ;
			}
			else
			{
				Component.Destroy( scriptPtr ) ;
				m_MainCharacterObj.AddComponent<CameraController_RotateAroundTarget01>() ;
				
				m_Valid = false ;// only add once
			}
		}
	}	
	
	
	private void InitializeCameraPtr()
	{
		m_CameraObject = (GameObject)Camera.main.gameObject ;
		
		if( null == m_CameraObject )
		{
			Debug.LogError( "ChangeScript01:InitializeCameraPtr() null == m_CameraObject" ) ;
		}
		else
		{
			Debug.Log( "ChangeScript01:InitializeCameraPtr() end." ) ;
		}
	}		
	
	private void InitializeMainCharacter()
	{
		m_MainCharacterObj = GameObject.FindGameObjectWithTag( "Player" ) ;
		
		if( null == m_MainCharacterObj )
		{
			Debug.LogError( "ChangeScript01:InitializeMainCharacter() null == m_MainCharacterObj" ) ;
		}
		else
		{
			Debug.Log( "ChangeScript01:InitializeMainCharacter() end." ) ;
		}
	}
}
