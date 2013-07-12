/**
 * @file RevolutionArroundObject01.cs
 * @author NDark
 * @date 20130712 . file started.
 */
using UnityEngine;
using System.Collections;

public class RevolutionArroundObject01 : MonoBehaviour 
{
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
		
	
		Vector3 centerToMe = this.gameObject.transform.position - m_CenterTarget.transform.position ;
		Vector3 rotateCenterToMe = Quaternion.AngleAxis( 1 , new Vector3( 0 , 1 , 0 ) ) * centerToMe ;
		
		this.transform.position = m_CenterTarget.transform.position + rotateCenterToMe ;
	}
	
	private void IntializeCenterTarget()
	{
		m_CenterTarget = GameObject.Find( "Crab" ) ;
		if( null == m_CenterTarget )
		{
			Debug.LogError( "RevolutionArroundObject01::IntializeCenterTarget() null == m_CenterTarget" ) ;
		}
		else
		{
			Debug.Log( "RevolutionArroundObject01::IntializeCenterTarget() end." ) ;
		}		
	}
}
