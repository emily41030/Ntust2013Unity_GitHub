/**
 * @file FightSystem.cs
 * @author NDark
 * @date 20140405 file started.
 */
using UnityEngine;
using System.Collections.Generic;

public enum FightSystemState
{
	UnActive = 0 ,
	Initialize ,
	Ready ,
	BattleInitialize ,
	BattleStartAnimation ,
	RefreshOptions ,
	WaitCharacterLeft ,
	WaitCharacterRight ,
	WaitAnimationAndJudgeVictory ,
	BattleEndAnimation ,
}

public class FightSystem : MonoBehaviour 
{
	private GameObject m_CharacterLeft = null ;
	private GameObject m_CharacterRight = null ;
	private GameObject m_DisplayCharacterLeft = null ; // 左顯示圖像
	private GameObject m_DisplayCharacterRight = null ; // 右顯示圖像

	private GameObject m_StatusBackground = null ;// 狀態框背景
	private int m_StatusStringIndex = 0 ; // 目前是顯示的狀態
	private List<string> m_StatusStringList = new List<string>() ; // 所有狀態
	private List<GameObject> m_DisplayStatusList = new List<GameObject>() ; // 狀態文字物件


	private GameObject m_OperationBackground = null ;// 操作框背景
	private int m_OperationStringIndex = 0 ; // 目前操作字串顯示所引
	private List<Operation> m_OperationOptionList = new List<Operation>() ; // 所有的操作
	private List<GameObject> m_DispalyOperationList = new List<GameObject>() ; // 顯示的操作字串物件

	private int m_SelectedOperationIndex = 0 ; // 目前選擇的操作(注意是0~5)
	private GameObject m_IndicateOperationSymbol = null ; // 標示目前選擇的操作的符號

	private List<SkillAnimation> m_SkillAnimationList = new List<SkillAnimation>() ;

	private FightSystemState m_FightSystemState = FightSystemState.UnActive ;

	public void StartABattle( GameObject _LeftCharacter , GameObject _RightCharacter )
	{
		m_CharacterLeft = _LeftCharacter ;
		m_CharacterRight = _RightCharacter ;
		m_FightSystemState = FightSystemState.BattleInitialize ;
	}

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		switch( m_FightSystemState )
		{
		case FightSystemState.UnActive :
			m_FightSystemState = FightSystemState.Initialize ;
			break ;
		case FightSystemState.Initialize :
			RetrieveUIObjects() ;
			break ;
		case FightSystemState.Ready :
			break ;
		case FightSystemState.BattleInitialize :
			InitBattle() ;
			break ;
		case FightSystemState.BattleStartAnimation :
			m_FightSystemState = FightSystemState.RefreshOptions ;
			break ;
		case FightSystemState.RefreshOptions :
			RefreshOptions() ;
			break ;
		case FightSystemState.WaitCharacterLeft :
			break ;
		case FightSystemState.WaitCharacterRight :
			m_FightSystemState = FightSystemState.WaitAnimationAndJudgeVictory ;
			break ;
		case FightSystemState.WaitAnimationAndJudgeVictory :
			m_FightSystemState = FightSystemState.RefreshOptions ;
			break ;
		case FightSystemState.BattleEndAnimation :
			break ;
		}
	}

	private void RefreshOptions()
	{
		// 依照玩家資料更新玩家的選項
		m_FightSystemState = FightSystemState.WaitCharacterLeft ;
	}

	private void InitBattle()
	{
		// 取得雙方的資料 傳入並建立角色的貼圖。取得角色資料，角色的招式資料。
		// 依照玩家資料更新玩家的選項
		m_FightSystemState = FightSystemState.BattleStartAnimation ;
	}

	private void RetrieveUIObjects() 
	{
		RetrieveGameObject( ref m_DisplayCharacterLeft , "FightSystemCharacterLeftObject" ) ;
		RetrieveGameObject( ref m_DisplayCharacterRight , "FightSystemCharacterRightObject" ) ;
		RetrieveGameObject( ref m_StatusBackground , "FightSystemStatusBackground" ) ;
		RetrieveGameObject( ref m_OperationBackground , "FightSystemOperationBackground" ) ;
		RetrieveOperationStringList( m_OperationBackground ) ;
		RetrieveStatusStringList( m_StatusBackground ) ;
		RetrieveGameObject( ref m_IndicateOperationSymbol , "IndicateOperationSymbol" ) ;
		m_FightSystemState = FightSystemState.Ready ;
	}

	private void RetrieveStatusStringList( GameObject _ParentObj ) 
	{
		if( null == _ParentObj )
			return ;
		
		for( int i = 0 ; i < 10 ; ++i )
		{
			string objectName = string.Format( "StatusText{0:00}" , i ) ;
			Transform trans = _ParentObj.transform.FindChild( objectName ) ;
			if( null != trans )
			{
				TextMesh tm = trans.gameObject.GetComponent<TextMesh>() ;
				tm.text = "" ;
				Debug.Log( "objectName" + objectName ) ;
				m_DispalyOperationList.Add( trans.gameObject ) ;
			}
		}
	}

	private void RetrieveOperationStringList( GameObject _ParentObj ) 
	{
		if( null == _ParentObj )
			return ;

		for( int i = 0 ; i < 10 ; ++i )
		{
			string objectName = string.Format( "OperationText{0:00}" , i ) ;
			Transform trans = _ParentObj.transform.FindChild( objectName ) ;
			if( null != trans )
			{
				TextMesh tm = trans.gameObject.GetComponent<TextMesh>() ;
				tm.text = "" ;
				Debug.Log( "objectName" + objectName ) ;
				m_DispalyOperationList.Add( trans.gameObject ) ;
			}
		}
	}

	private void RetrieveGameObject( ref GameObject _Obj , string _ObjectName ) 
	{
		_Obj = GameObject.Find( _ObjectName ) ;
		if( null == _Obj )
		{
			Debug.LogError( "RetrieveGameObject():" + _ObjectName + "is not found." ) ;
		}
	}
}
