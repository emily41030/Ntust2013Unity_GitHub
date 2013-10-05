/*
@file DrivingCar01.cs
@author NDark
@date 20131005 file started.
*/
using UnityEngine;

public class DrivingCar01 : MonoBehaviour 
{
	public WheelCollider m_WheelCollderFR = null ;
	public WheelCollider m_WheelCollderFL = null ;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( null != m_WheelCollderFR &&
			null != m_WheelCollderFL )
		{
			m_WheelCollderFR.motorTorque = 260 * Input.GetAxis("Vertical") ;
			m_WheelCollderFL.motorTorque = 260 * Input.GetAxis("Vertical") ;
		
			m_WheelCollderFR.steerAngle = 10 * Input.GetAxis("Horizontal") ;
			m_WheelCollderFL.steerAngle = 10 * Input.GetAxis("Horizontal") ;
		}
	}
}
