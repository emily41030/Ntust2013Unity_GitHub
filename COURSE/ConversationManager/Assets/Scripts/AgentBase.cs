/**
 * @file AgentBase.cs
 * @author NDark
 * @date 20140322 . file started.
 */
using UnityEngine;
using System.Collections;

public enum AgentState
{
	Condition,
	Action,
	Fighting,
}

public class AgentBase
{


	public AgentBase( string _Name )
	{
		Name = _Name ;
	}

	public string Name
	{
		get { return m_Name ; } 
		set { m_Name = value ; }
	}
	private string m_Name = "" ;

	public bool IsValid
	{
		get { return m_IsValid ; }
		set { m_IsValid = value ; }
	}
	private bool m_IsValid = true ;

	public AgentState State
	{
		get 
		{ 
			return ReadAgentState() ; 
		}
		set 
		{ 
			WriteAgentState( value ) ;
			m_AgentState = value ; 
		}
	}
	private AgentState m_AgentState = AgentState.Condition ;

	public ConditionBase Condition
	{
		get { return m_Condition ; }
		set { m_Condition = value ; }
	}
	private ConditionBase m_Condition = null ;

	public ActionBase Action
	{
		get { return m_Action ; }
		set { m_Action = value ; }
	}
	private ActionBase m_Action = null ;

	public void DoUpdate()
	{
		ReadAgentState() ;
		switch( m_AgentState )
		{
		case AgentState.Condition :
			DoCondition() ;
			break ;
		case AgentState.Action :
			DoAction() ;
			break ;
		case AgentState.Fighting :
			break ;
		}
	}

	private AgentState ReadAgentState()
	{
		// read from property
		// m_AgentState = 
		return m_AgentState ;
	}

	private void WriteAgentState( AgentState _Set )
	{
		// Set to property
		m_AgentState = _Set ;
	}

	protected virtual void DoCondition()
	{
		if( null != m_Condition )
		{
			m_Condition.DoCondition() ;
		}
	}

	protected virtual void DoAction()
	{
		if( null != m_Action )
		{
			m_Action.DoAction() ;
		}
	}

}
