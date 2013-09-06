/*
@file KandyCrusherManager.cs
@author NDark
@date 20130906 file started.
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class KandyCrusherManager : MonoBehaviour 
{
	
	public enum KandyCrusherState
	{
		UnActive ,
		Droping ,
		Judge ,
		Destroy ,
		WaitingInput , 
		Swap, 
	}
	
	public KandyCrusherState m_State = KandyCrusherState.UnActive ;
	public List<GameObject> m_EmptyBoards = new List<GameObject>() ;
	public Dictionary<int , GameObject> m_Units = new Dictionary<int, GameObject>() ;
	public int m_WidthNum = 1 ;
	public int m_HeightNum = 1 ;
	public int m_Iter = 0 ;
	
	public GameObject m_UnitCollector = null ;
	
	// Use this for initialization
	void Start () 
	{
		
		if( null == m_UnitCollector )
		{
			m_UnitCollector = GameObject.Find( "UnitCollector" ) ;
		}
		
		
		
		InitializeAllUnits() ;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void InitializeAllUnits()
	{
		for( int j = 0 ; j < m_HeightNum ; ++j )
		{
			for( int i = 0 ; i < m_WidthNum ; ++i )
			{
				GameObject newObj = GenerateUnit( i , j ) ;
				if( null != newObj )
				{
					m_Units.Add( j * m_HeightNum + i , newObj ) ;
				}
			}
		}
	}
	
	GameObject GenerateUnit( int _i , int _j )
	{
		GameObject ret = null ;
		
		int index = Random.Range( 1 , 5 ) ;
		string prefabName = string.Format( "AlienUnit{0:00}" , index ) ;
		Object prefab = Resources.Load( prefabName ) ;
		if( null == prefab )
			Debug.LogError( "null == prefab" + prefabName ) ;
		else
		{
			ret = (GameObject) GameObject.Instantiate( prefab ) ;
			ret.name = "Unit" + m_Iter.ToString() ;
			++m_Iter ;
			
			if( null != m_UnitCollector )
			{
				ret.transform.parent = m_UnitCollector.transform ;
			}
	
			ret.transform.position = m_EmptyBoards[ _j * m_HeightNum + _i ].transform.position ;
		}
		return ret ;
	}
}
