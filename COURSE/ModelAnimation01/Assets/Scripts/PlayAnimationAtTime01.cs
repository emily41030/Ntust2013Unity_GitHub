/*
@file PlayAnimationAtTime01.cs
@author NDark
@date 20130908 file started.
*/
using UnityEngine;

public class PlayAnimationAtTime01 : MonoBehaviour 
{
	public string m_AnimationStr = "" ;
	public float m_AnimationTime = 0.0f ;
	
	public void PlayAnimationAtSpecifiedTime() 
	{
		// Debug.Log( "PlayAnimationAtSpecifiedTime" ) ;
		if( null == this.animation[ m_AnimationStr ] )
			return ;
		this.animation[ m_AnimationStr ].time = m_AnimationTime ;
		this.animation[ m_AnimationStr ].speed = 0.0f  ;
		this.animation.Play( m_AnimationStr ) ;			
	}
	
	// Use this for initialization
	void Start () 
	{
			
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
