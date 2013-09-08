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
	
	// 定義尋找的方向
	public enum Direction
	{
		Up = 0 ,
		Down = 1 ,
		Right = 2 ,
		Left = 3 ,
	}
	
	public enum KandyCrusherState
	{
		UnActive ,
		CheckDrop , 	// 檢查掉落
		Droping , 		// 掉落中
		JudgeDestroy ,  // 檢查摧毀
		Destroy ,		// 摧毀中
		WaitingPress , 
		WaitingRelease ,
		Swap, 
	}
	
	public KandyCrusherState m_State = KandyCrusherState.UnActive ;
	public List<GameObject> m_EmptyBoards = new List<GameObject>() ;
	public Dictionary<int , GameObject> m_Units = new Dictionary<int, GameObject>() ;
	public int m_WidthNum = 1 ;
	public int m_HeightNum = 1 ;
	public int m_Iter = 0 ;
	
	public GameObject m_UnitCollector = null ;
	
	public int m_PressIndex = -1 ;
	public int m_ReleaseIndex = -1 ;
	
	public void InputPress( int _i , int _j ) 
	{
		if( KandyCrusherState.WaitingPress != m_State )
			return ;
		m_PressIndex = _j * m_WidthNum + _i ;
		m_State = KandyCrusherState.WaitingRelease ;
	}
	
	public void InputRelease( int _i , int _j ) 
	{
		if( KandyCrusherState.WaitingPress != m_State )
			return ;		
		m_ReleaseIndex = _j * m_WidthNum + _i ;
		AddSwap( m_PressIndex , m_ReleaseIndex ) ;
		m_State = KandyCrusherState.Swap ;
	}	
	
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
	void Update () 
	{
		switch( m_State )
		{
		case KandyCrusherState.UnActive :
			m_State = KandyCrusherState.CheckDrop ;
			break ;
		case KandyCrusherState.CheckDrop :
			CheckDrop() ;
			break ;
		case KandyCrusherState.Droping :
			CheckDroping() ;
			break ;
		case KandyCrusherState.JudgeDestroy :
			// 檢查是否有需要消滅
			JudgeDestroy() ;
			break ;	
		case KandyCrusherState.Destroy :
			// 消滅動畫檢查結束,回到 CheckDrop
			CheckDestroy() ;
			break ;	
		case KandyCrusherState.WaitingPress :
			// 等待按下
			break ;	
		case KandyCrusherState.WaitingRelease :
			// 等待放開 
			break ;				
		case KandyCrusherState.Swap :
			// 等待交換動畫結束
			CheckSwapEnd() ;
			break ;				
		}
	
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
					m_Units.Add( j * m_WidthNum + i , newObj ) ;
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
			
			// 設定unit data
			UnitData script = ret.AddComponent<UnitData>() ;
			script.m_IndexI = _i ;
			script.m_IndexJ = _j ;
			script.m_UnitType = index ;
			
			
			// 設定parent
			if( null != m_UnitCollector )
			{
				ret.transform.parent = m_UnitCollector.transform ;
			}
	
			// 設定位置
			// Debug.Log( _j * m_WidthNum + _i ) ;
			ret.transform.position = m_EmptyBoards[ _j * m_WidthNum + _i ].transform.position ;
		}
		return ret ;
	}
	
	private void CheckDrop()
	{
		HashSet<int> dropIndices = new HashSet<int>() ;
		
		int currentIndex = 0 ;
		int downIndex = 0 ;
		// 由下而上
		Dictionary<int , GameObject>.Enumerator iU = m_Units.GetEnumerator() ;
//		while( iU.MoveNext() )
//		{
//			Debug.Log( "CheckDrop() iU=" + iU.Current.Key ) ;
//		}
//		iU = m_Units.GetEnumerator() ;
		
		while( iU.MoveNext() )
		{
			currentIndex = iU.Current.Key ;
			downIndex = currentIndex - m_WidthNum ;// 越下面index越少
			// Debug.Log( "CheckDrop() downIndex=" + downIndex ) ;
			if( true == IsValidIndex( downIndex ) &&
				false == m_Units.ContainsKey( downIndex ) )
			{
				// drop index
				dropIndices.Add( currentIndex ) ;
// #if DEBUG
				Debug.Log( "CheckDrop() dropIndices.Add=" + currentIndex ) ;
// #endif				
			}
		}
		
		foreach( int index in dropIndices )
		{
			GameObject dropObj = m_Units[ index ] ;
			// 修改index
			UnitData unitData = dropObj.GetComponent<UnitData>() ;
			if( null == unitData )
				break ;
			
			int newIndex = unitData.m_IndexJ * m_WidthNum + unitData.m_IndexI - m_WidthNum ;
			
			if( false == IsValidIndex( newIndex ) )
				continue;
			
			unitData.m_IndexJ -= 1 ;
			// 掉落動畫 設定目標
			CloseTarget moveAnim = dropObj.GetComponent<CloseTarget>() ;
			if( null == moveAnim )
			{
				moveAnim = dropObj.AddComponent<CloseTarget>() ;
			}
			m_Units.Remove( index ) ;
			m_Units.Add( newIndex , dropObj ) ;
#if DEBUG			
			// Debug.Log( "dropTo=" + newIndex ) ;
#endif			
			moveAnim.m_TargetPos = m_EmptyBoards[ newIndex ].transform.position ;			
		}
		
		
		
		if( dropIndices.Count > 0 )
		{
			FillTopUnits() ;
			this.m_State = KandyCrusherState.Droping ;
		}
		else
		{
			this.m_State = KandyCrusherState.JudgeDestroy ;
		}
	}
	
	private void CheckDroping()
	{
		// 檢查掉落結束了沒有, 回到 CheckDrop
		
		// 由下而上
		Dictionary<int , GameObject>.Enumerator iU = m_Units.GetEnumerator() ;
		while( iU.MoveNext() )
		{
			GameObject unit = iU.Current.Value ;
			CloseTarget script = unit.GetComponent<CloseTarget>() ;
			if( null != script )// 有一個單位還在掉
			{
				
			}
		}
		
		
		FillTopUnits() ;
		
		
		// Debug.Log( "CheckDroping() end droping" ) ;
		this.m_State = KandyCrusherState.CheckDrop ;
	}
	
	private void JudgeDestroy()
	{
		// Debug.Log( "JudgeDestroy()" + m_EmptyBoards.Count ) ;
		
		
		HashSet<int> oneTimedestroyList = new HashSet<int>() ;
		HashSet<int> totalDestroyList = new HashSet<int>() ;
		
		Dictionary<int , GameObject>.Enumerator iU = m_Units.GetEnumerator() ;
		while( iU.MoveNext() )
		{
			GameObject unit = iU.Current.Value ;
			UnitData unitData = unit.GetComponent<UnitData>() ;
			if( null != unitData )
			{
				// 往右
				oneTimedestroyList.Clear() ;
				
				// Debug.Log( "isChecked.Count= " + isChecked.Count ) ;
				ContinueFindDestroy( unitData.m_IndexI ,
					unitData.m_IndexJ ,
					unitData.m_UnitType ,
					Direction.Right ,
					ref oneTimedestroyList ) ;
			
				if( oneTimedestroyList.Count > 2 )
				{
					foreach( int i in oneTimedestroyList )
					{
						totalDestroyList.Add( i ) ;
					}
				}
				
				// 往上
				oneTimedestroyList.Clear() ;
				
				ContinueFindDestroy( unitData.m_IndexI ,
					unitData.m_IndexJ ,
					unitData.m_UnitType ,
					Direction.Up ,
					ref oneTimedestroyList ) ;				
				
				if( oneTimedestroyList.Count > 2 )
				{
					foreach( int i in oneTimedestroyList )
					{
						totalDestroyList.Add( i ) ;
					}
				}				
			}
		}
		
		if( totalDestroyList.Count > 0 )
		{
			// 新增 清除動畫 
			foreach( int i in totalDestroyList )
			{
#if DEBUG				
				Debug.Log( "JudgeDestroy() totalDestroyList " + i ) ;
#endif				
				GameObject obj = m_Units[ i ] ;
				obj.AddComponent<VanishAnim>() ; 
			}
			m_State = KandyCrusherState.Destroy ;
		}
		else
		{
			m_State = KandyCrusherState.WaitingPress ;
		}
		
	}
	
	void ContinueFindDestroy( int _i , 
							  int _j , 
							  int _Type , 
							  Direction _FindingDirection ,
							  ref HashSet<int> _DestroyList ) 
	{
#if DEBUG			
		Debug.Log( "RecursiveFindDestroy() " + _i + "," + _j + "," + _Type ) ;
#endif
		
		if( false == IsValidIndex( _i , _j ) )
		{
#if DEBUG				
			Debug.Log( "false == IsValidIndex" ) ;
#endif			
			return ;
		}
		
		int index = _j * m_WidthNum + _i ;
		
		if( false == m_Units.ContainsKey( index ) )
		{
#if DEBUG						
			Debug.Log( "false == m_Units.ContainsKey" ) ;
#endif
			
			return ;
		}
		
		GameObject unit = m_Units[ index ] ;
		UnitData unitData = unit.GetComponent<UnitData>() ;
		if( null == unitData )
			return ;
		if( unitData.m_UnitType != _Type )
		{
#if DEBUG			
			Debug.Log( "unitData.m_UnitType != _Type" + unitData.m_UnitType ) ;
#endif			
			return ;
		}
#if DEBUG		
		Debug.Log( "_DestroyList.Add " + index ) ;
#endif		
		_DestroyList.Add( index ) ;
		
		if( _FindingDirection == Direction.Right )
			ContinueFindDestroy( _i + 1 , _j , _Type , _FindingDirection  , ref _DestroyList ) ;
		// else if( _FindingDirection == Direction.Left )
		// 	ContinueFindDestroy( _i - 1 , _j , _Type , _FindingDirection , ref _DestroyList ) ;
		else if( _FindingDirection == Direction.Up )
			ContinueFindDestroy( _i , _j + 1 , _Type , _FindingDirection , ref _DestroyList ) ;
		// else if( _FindingDirection == Direction.Down )
		// 	ContinueFindDestroy( _i , _j - 1 , _Type , _FindingDirection , ref _DestroyList ) ;
	}
	
	private bool IsValidIndex( int _index )
	{
		if( _index < 0 || _index >= m_HeightNum * m_WidthNum )
			return false ;
		return true ;
	}
	private bool IsValidIndex( int _i , int _j )
	{
		if( _i < 0 || 
			_i >= m_WidthNum ||
			_j < 0 || 
			_j >= m_HeightNum )
			return false ;
		return true ;
	}
	
	private void AddSwap( int _index1 , int _index2 )
	{
		if( false == m_Units.ContainsKey( _index1 ) || 
			false == m_Units.ContainsKey( _index2 )  )
			return ;
		
		GameObject obj1 = m_Units[ _index1 ] ;
		UnitData unitDat1 = obj1.GetComponent<UnitData>() ;
		GameObject obj2 = m_Units[ _index1 ] ;
		UnitData unitDat2 = obj2.GetComponent<UnitData>() ;
		
		if( null == unitDat1 || 
			null == unitDat2 )
			return ;
		
		
		int tmp ;
		tmp = unitDat1.m_IndexI ;
		unitDat1.m_IndexI = unitDat2.m_IndexI ;
		unitDat2.m_IndexI = tmp ;
	
		tmp = unitDat1.m_IndexJ ;
		unitDat1.m_IndexJ = unitDat2.m_IndexJ ;
		unitDat2.m_IndexJ = tmp ;
				
		m_Units[ _index1 ] = obj2 ;
		m_Units[ _index2 ] = obj1 ;
		
		// add animation
		CloseTarget animScript = obj1.AddComponent<CloseTarget>() ;
		animScript.m_TargetPos = obj2.transform.position ;
		
		animScript = obj2.AddComponent<CloseTarget>() ;
		animScript.m_TargetPos = obj1.transform.position ;
	}
	
	private void CheckSwapEnd()
	{
		if( false == m_Units.ContainsKey( m_PressIndex ) || 
			false == m_Units.ContainsKey( m_ReleaseIndex )  )
			return ;
		
		GameObject obj1 = m_Units[ m_PressIndex ] ;
		GameObject obj2 = m_Units[ m_ReleaseIndex ] ;
		if( null != obj1.GetComponent<CloseTarget>() ||
			null != obj2.GetComponent<CloseTarget>() )
			return ;
		
		m_State = KandyCrusherState.CheckDrop ;
	}

	private void CheckDestroy()
	{
		bool animEnd = true ;
		List<int> destroyList = new List<int>() ;
		Dictionary<int , GameObject>.Enumerator iU = m_Units.GetEnumerator() ;
		while( iU.MoveNext() )
		{
			VanishAnim animScript = iU.Current.Value.GetComponent<VanishAnim>() ;
			if( null != animScript )
			{
				if( false == animScript.IsAnimEnd() )
				{
					animEnd = false ;
				}
				else
				{
					destroyList.Add( iU.Current.Key ) ;
				}
			}
		}
		
		if( true == animEnd )
		{
		
			foreach( int i in destroyList )
			{
				GameObject obj = m_Units[ i ] ;
				GameObject.Destroy(obj) ;
				m_Units.Remove( i ) ;
			}
			m_State = KandyCrusherState.CheckDrop ;
		}
	}
	
	private void FillTopUnits()
	{
		// 填補最上層的單位
		int j = m_HeightNum - 1 ;
		for( int i = 0 ; i < m_WidthNum ; ++i )
		{
			int index = j * m_WidthNum + i ;
			if( false == m_Units.ContainsKey( index ) )
			{
				m_Units.Add( index, GenerateUnit( i , j ) );
			}
		}		
	}
}
