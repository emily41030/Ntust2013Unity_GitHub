/*
@file TDUnitManager01.cs
@author NDark
@date 20130824 file started.
*/
using UnityEngine;
using System.Collections;

public class TDUnitManager01 : MonoBehaviour 
{
	public int [] m_UnitID = 
	{
		1 , 2 , 3 , 4 ,
		11, 12 , 13 , 14 ,
		21 , 22 , 23 , 24 ,
		25 , 26 , 27 , 28 , 99 
	} ;	
	public bool [] m_IsTriggered ;
	public float [] m_TriggerSec = 
	{
		1 , 2 , 3 , 4 ,
		8 , 9 , 10 , 11 ,
		15 , 17 , 19 , 21 ,
		23 , 25 , 27 , 30 , 35 
	} ;
	
	// Use this for initialization
	void Start () 
	{
		m_IsTriggered = new bool[ m_TriggerSec.Length ] ;
		for( int i = 0 ; i < m_IsTriggered.Length ; ++i )
		{
			m_IsTriggered[ i ] = false ;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		for( int i = 0 ; 
			 i < m_IsTriggered.Length && 
			 i < m_TriggerSec.Length ; 
			 ++i )
		{
			if( true == m_IsTriggered[ i ] )
				continue ;
			
			if( Time.timeSinceLevelLoad > m_TriggerSec[ i ] )
			{
				string unitName = 
					string.Format( "AlienUnit{0:00}" , m_UnitID[ i ] ) ;
				
				TriggTDUnit( unitName ) ;
				
				m_IsTriggered[ i ] = true ;
			}
		}
	
	}
					
	private void TriggTDUnit( string _Name ) 
	{
		Debug.Log( _Name ) ;
		
		GameObject unit = GameObject.Find( _Name ) ;
		
		if( null == unit )
			return ;
		
		MoveFollowWayPoint01 script = unit.GetComponent<MoveFollowWayPoint01>() ;
		if( null == script )
		{
			script = unit.AddComponent<MoveFollowWayPoint01>() ;
			// do some setting ?
		}
	}
				
}
