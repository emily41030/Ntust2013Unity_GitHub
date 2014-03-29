/*
@file UnitDataParam.cs
@author NDark
@date 20140329 file started.
*/
#define DEBUG_SHOW_STANDARD_PARAMETER
using UnityEngine;
using System.Collections.Generic;

public class UnitDataParam : UnitData 
{
	public Dictionary< string , StandardParameter > standardParameters = new Dictionary< string , StandardParameter >() ;
	public StandardParameter [] Debug_standardParameters = null ;

	public void AssignStandardParameter( string _Key , 
	                                     StandardParameter _Parameter )
	{
		standardParameters[ _Key ] = new StandardParameter( _Parameter ) ;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
#if DEBUG_SHOW_STANDARD_PARAMETER
		Debug_standardParameters = new StandardParameter[ this.standardParameters.Count ] ;
		this.standardParameters.Values.CopyTo( Debug_standardParameters , 0 ) ;
#endif // #if DEBUG_SHOW_STANDARD_PARAMETER

	
	}
}
