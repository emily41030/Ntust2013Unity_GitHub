/**
 * @file Take.cs
 * @author NDark
 * @date20140308 file started.
 */
using UnityEngine;
using System.Collections.Generic ;

public class Take
{
	public int UID
	{
		get { return m_UID ; }
		set { m_UID = value ; }
	}
	private int m_UID = 0 ;
	
	public float WaitingTime
	{
		get { return m_WaitingTime ; }
		set { m_WaitingTime = value ; }
	}
	private float m_WaitingTime = 0 ;
	
	public List<string> Potraits
	{
		get { return m_Potraits ; }
		set { m_Potraits = value ; }
	}
	private List<string> m_Potraits = new List<string>() ;
	
	public List<string> Contents
	{
		get { return m_Contents ; }
		set { m_Contents = value ; }
	}
	private List<string> m_Contents = new List<string>() ;
}
