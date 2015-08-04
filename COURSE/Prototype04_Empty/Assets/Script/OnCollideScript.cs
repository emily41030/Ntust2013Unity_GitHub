/**
@file OnCollideScript.cs
@author NDark
@date 20130809 file started.
*/
using UnityEngine;

public class OnCollideScript : MonoBehaviour 
{
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{	
	}
	
	
	void OnTriggerEnter( Collider other )
	{
		Debug.Log( "OnTriggerEnter=" + other.gameObject.name ) ;

		GameObject.Destroy( this.gameObject ) ;
		GameObject.Destroy( other.gameObject ) ;
	}
	
}
