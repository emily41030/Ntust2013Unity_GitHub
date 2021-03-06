/*
@file ReleaseMissle01.cs
@author NDark
@file 20130804 file started.
@date 20130809 by NDark . add class member m_TargetObject.
*/
using UnityEngine;
using System.Collections.Generic ;

public class ReleaseMissle01 : MonoBehaviour 
{
	public enum ReleaseState
	{
		Ready ,
		Fire ,
		Reload 
	}
	
	public ReleaseState m_State = ReleaseState.Reload ;
	public int m_Iterator = 0 ;
	public float m_FireTime = 0.0f ;
	public float m_ReloadSec = 5.0f ;
	public GameObject m_TargetObject = null ;
	
	
	// Use this for initialization
	void Start () 
	{
		InstantiateMissle() ;
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch( m_State )
		{
		case ReleaseState.Ready :
			m_State = ReleaseState.Fire ;
			break ;
		case ReleaseState.Fire :
			InstantiateMissle() ;
			m_State = ReleaseState.Reload ;
			m_FireTime = Time.timeSinceLevelLoad ;
			break ;
		case ReleaseState.Reload :
			if( Time.timeSinceLevelLoad > m_FireTime + m_ReloadSec )
			{
				m_State = ReleaseState.Ready ;
			}
			break ;
		}
	}
	
	private void InstantiateMissle()
	{
		Object prefab = Resources.Load( "Missle" ) ;
		if( null != prefab )
		{
			GameObject missle = 
				(GameObject) Instantiate( prefab ) ;
			missle.name = "missle" + m_Iterator.ToString() ;
			
			missle.transform.position = this.transform.position ;
			missle.transform.rotation = this.transform.rotation ;
			++m_Iterator ;
		
			MissleLanchAndGotoTarget01 script = missle.GetComponent<MissleLanchAndGotoTarget01>() ;
			if( null != script )
			{
				script.m_InitialDirection = Random.onUnitSphere ;
				script.m_InitialDirection.z = 0 ;
				script.m_InitialDirection.y = Mathf.Abs( script.m_InitialDirection.y ) ;
				if( null == m_TargetObject )
					m_TargetObject = Camera.mainCamera.gameObject ;
				script.m_Target = m_TargetObject ;
			}
		}
	}
}
