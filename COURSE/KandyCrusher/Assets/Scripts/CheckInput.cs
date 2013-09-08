/*
@file CheckInput.cs
@author NDark
@date 20130908 file started.
*/
using UnityEngine;

public class CheckInput : MonoBehaviour 
{
	static KandyCrusherManager s_Manager = null ;
	public UnitData m_UnitData = null ;
	
	// Use this for initialization
	void Start () 
	{
		if( null == s_Manager )
		{
			GameObject obj = GameObject.Find( "GlobalSingleton" ) ;
			s_Manager = obj.GetComponent<KandyCrusherManager>() ;
		}
	
		m_UnitData = this.gameObject.GetComponent<UnitData>() ;
	}
	
	// Update is called once per frame
	void Update () 
	{

	
	}
	
	void OnMouseDown()
	{
		if( null != s_Manager &&
			null != m_UnitData ) 
		{
			Debug.Log( this.gameObject.name ) ;
			s_Manager.InputPress( m_UnitData.m_IndexI , m_UnitData.m_IndexJ ) ;
		}
	}
	
	void OnMouseUp()
	{
		if( null != s_Manager &&
			null != m_UnitData ) 
		{
			Debug.Log( this.gameObject.name ) ;
			s_Manager.InputRelease( m_UnitData.m_IndexI , m_UnitData.m_IndexJ ) ;
		}
	}	
}
