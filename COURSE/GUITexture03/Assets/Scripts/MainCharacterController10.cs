using UnityEngine;
using System.Collections;

public class MainCharacterController10 : MonoBehaviour 
{
	DestinationController01 m_DestinationController = null ;
	public float m_Speed = 1.0f ;
	public float m_ReacThreashold = 0.2f ;

	// Use this for initialization
	void Start () 
	{
		if( null == m_DestinationController )
			InitDestinationController() ;
			
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( null == m_DestinationController )
			return ;
	
		if( true == m_DestinationController.m_IsShowDestination )
		{
			Vector3 destinationPos = m_DestinationController.m_Destination3DPos ;
			Vector3 diffVec = destinationPos - this.gameObject.transform.position ;
			Debug.Log( diffVec.sqrMagnitude ) ;
			if( diffVec.sqrMagnitude < m_ReacThreashold )
			{
				m_DestinationController.ShowDestination( false , destinationPos ) ;
			}
			else
			{
				Vector3 nextPos = Vector3.Lerp( this.gameObject.transform.position , destinationPos , m_Speed * Time.deltaTime ) ;
				this.gameObject.transform.position = nextPos ;
				this.gameObject.transform.rotation = Quaternion.LookRotation( diffVec ) ;
			}
		}
		
	}
	
	private void InitDestinationController()
	{
		GameObject globalSingleton = GameObject.Find( "GlobalSingleton" ) ;
		
		if( null != globalSingleton )
		{
			m_DestinationController = globalSingleton.GetComponent<DestinationController01>() ;
		}
	}	
}
