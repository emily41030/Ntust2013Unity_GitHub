/*
@file OnGUI01.cs
@author NDark
@date 20130721 . file started.

*/
using UnityEngine;
using System.Collections;

public class OnGUI01 : MonoBehaviour 
{
	public Texture m_Texture1 = null ;
	public GUIStyle m_Style1 = new GUIStyle() ;
	public GUISkin m_Skin1 = null ;
	 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		DrawGUIBox() ;
		DrawGUIButton() ;
		DrawGUIToggle() ;
	}
	
	
	private void DrawGUIBox()
	{
		{
			Rect box1Rect = new Rect( 0 , 0 , 100 , 50 ) ;
			GUI.Box( box1Rect , "Box1" ) ;
		}
		
		{
			Rect box2Rect = new Rect( 0 , 70 , 100 , 50 ) ;
			GUI.Box( box2Rect , "Box2" ) ;
		}

		{
			Rect box3Rect = new Rect( 0 , 140 , 100 , 50 ) ;
			GUI.Box( box3Rect , "" ) ;
		}

		{
			Rect box4Rect = new Rect( 0 , 210 , 100 , 50 ) ;
			GUI.Box( box4Rect , "box4box4box4box4" ) ;
		}
		
		if( null != m_Texture1 )
		{
			Rect box5Rect = new Rect( 0 , 280 , 100 , 50 ) ;
			GUI.Box( box5Rect , m_Texture1 ) ;
		}
		
		if( null != m_Texture1 )
		{
			Rect box6Rect = new Rect( 0 , 350 , 100 , 50 ) ;
			GUI.Box( box6Rect , new GUIContent ( m_Texture1 ) ) ;
		}
		
		if( null != m_Texture1 )
		{
			Rect box7Rect = new Rect( 0 , 420 , 100 , 50 ) ;
			GUI.Box( box7Rect , new GUIContent ( "box7" , m_Texture1 ) ) ;
		}
		
		{
			Rect box8Rect = new Rect( 0 , 490 , 100 , 50 ) ;
			GUI.Box( box8Rect , new GUIContent ( "box8" , "box8 tooltip" ) ) ;
			
			Rect tooltipRect = new Rect( Input.mousePosition.x , 
									     Screen.height - Input.mousePosition.y , 
										 100 , 50 ) ;
			GUI.Label( tooltipRect , GUI.tooltip ) ;
		}
		
		{
			Rect box9Rect = new Rect( 0 , 560 , 100 , 50 ) ;
			GUI.Box( box9Rect , "box9box9box9" , m_Style1 ) ;	
		}
		
		if( null != m_Texture1 )
		{
			Rect box10Rect = new Rect( 0 , 630 , 100 , 50 ) ;
			GUI.Box( box10Rect , m_Texture1 , m_Style1 ) ;	
		}
		
		
		GUI.skin = m_Skin1 ;
		{
			Rect box11Rect = new Rect( 0 , 700 , 100 , 25 ) ;
			GUI.Box( box11Rect , "box11" ) ;	
		}		
		GUI.skin = null ;
		{
			Rect box12Rect = new Rect( 0 , 725 , 100 , 25 ) ;
			GUI.Box( box12Rect , "box12" ) ;	
		}					
	}
	
	private void DrawGUIButton()
	{
		{
			Rect button1Rect = new Rect( 150, 0 , 100 , 50 ) ;
			GUI.Button( button1Rect , "Button1" ) ;
		}
		
		{
			Rect button2Rect = new Rect( 150, 70 , 100 , 50 ) ;
			GUI.Button( button2Rect , "Button2" ) ;
		}

		{
			Rect button3Rect = new Rect( 150, 140 , 100 , 50 ) ;
			GUI.Button( button3Rect , "" ) ;
		}

		{
			Rect button4Rect = new Rect( 150, 210 , 100 , 50 ) ;
			GUI.Button( button4Rect , "button4button4" ) ;
		}
		
		if( null != m_Texture1 )
		{
			Rect button5Rect = new Rect( 150, 280 , 100 , 50 ) ;
			GUI.Button( button5Rect , m_Texture1 ) ;
		}
		
		if( null != m_Texture1 )
		{
			Rect button6Rect = new Rect( 150, 350 , 100 , 50 ) ;
			GUI.Button( button6Rect , new GUIContent ( m_Texture1 ) ) ;
		}
		
		if( null != m_Texture1 )
		{
			Rect button7Rect = new Rect( 150, 420 , 100 , 50 ) ;
			GUI.Button( button7Rect , new GUIContent ( "button7" , m_Texture1 ) ) ;
		}
		
		{
			Rect button8Rect = new Rect( 150, 490 , 100 , 50 ) ;
			GUI.Button( button8Rect , new GUIContent ( "button8" , "button8 tooltip" ) ) ;
			
			Rect tooltipRect = new Rect( Input.mousePosition.x , 
									     Screen.height - Input.mousePosition.y , 
										 100 , 50 ) ;
			GUI.Label( tooltipRect , GUI.tooltip ) ;
		}
		
		{
			Rect button9Rect = new Rect( 150, 560 , 100 , 50 ) ;
			GUI.Button( button9Rect , "box9box9box9" , m_Style1 ) ;	
		}
		
		if( null != m_Texture1 )
		{
			Rect button10Rect = new Rect( 150, 630 , 100 , 50 ) ;
			GUI.Button( button10Rect , m_Texture1 , m_Style1 ) ;	
		}
		
		
		GUI.skin = m_Skin1 ;
		{
			Rect button11Rect = new Rect( 150, 700 , 100 , 25 ) ;
			GUI.Button( button11Rect , "button11" ) ;	
		}		
		GUI.skin = null ;
		{
			Rect button12Rect = new Rect( 150, 725 , 100 , 25 ) ;
			GUI.Button( button12Rect , "button12" ) ;	
		}					
	}	
	
	private bool m_ToggleValue = false ;
	private void DrawGUIToggle()
	{
		{
			Rect toggle1Rect = new Rect( 300, 0 , 100 , 50 ) ;
			m_ToggleValue = GUI.Toggle( toggle1Rect , m_ToggleValue , "toggle1" ) ;
		}
		
		{
			Rect toggle2Rect = new Rect( 300, 70 , 100 , 50 ) ;
			GUI.Toggle( toggle2Rect , m_ToggleValue , "toggle2" ) ;
		}

		{
			Rect toggle3Rect = new Rect( 300, 140 , 100 , 50 ) ;
			GUI.Toggle( toggle3Rect , m_ToggleValue, "" ) ;
		}

		{
			Rect toggle4Rect = new Rect( 300, 210 , 100 , 50 ) ;
			m_ToggleValue = GUI.Toggle( toggle4Rect , m_ToggleValue , "button4button4" ) ;
		}
		
		if( null != m_Texture1 )
		{
			Rect toggle5Rect = new Rect( 300, 280 , 100 , 50 ) ;
			GUI.Toggle( toggle5Rect , m_ToggleValue , m_Texture1 ) ;
		}
		
		if( null != m_Texture1 )
		{
			Rect toggle6Rect = new Rect( 300, 350 , 100 , 50 ) ;
			GUI.Toggle( toggle6Rect , m_ToggleValue , new GUIContent ( m_Texture1 ) ) ;
		}
		
		if( null != m_Texture1 )
		{
			Rect toggle7Rect = new Rect( 300, 420 , 100 , 50 ) ;
			GUI.Toggle( toggle7Rect , m_ToggleValue , new GUIContent ( "toggle7" , m_Texture1 ) ) ;
		}
		
		{
			Rect toggle8Rect = new Rect( 300, 490 , 100 , 50 ) ;
			GUI.Toggle( toggle8Rect , m_ToggleValue , new GUIContent ( "toggle8" , "toggle8 tooltip" ) ) ;
			
			Rect tooltipRect = new Rect( Input.mousePosition.x , 
									     Screen.height - Input.mousePosition.y , 
										 100 , 50 ) ;
			GUI.Label( tooltipRect , GUI.tooltip ) ;
		}
		
		{
			Rect toggle9Rect = new Rect( 300, 560 , 100 , 50 ) ;
			GUI.Toggle( toggle9Rect , m_ToggleValue , "toggle9toggle9toggle9" , m_Style1 ) ;	
		}
		
		if( null != m_Texture1 )
		{
			Rect toggle10Rect = new Rect( 300, 630 , 100 , 50 ) ;
			GUI.Toggle( toggle10Rect , m_ToggleValue , m_Texture1 , m_Style1 ) ;	
		}
		
		
		GUI.skin = m_Skin1 ;
		{
			Rect toggle11Rect = new Rect( 300, 700 , 100 , 25 ) ;
			GUI.Toggle( toggle11Rect , m_ToggleValue , "toggle11" ) ;	
		}		
		GUI.skin = null ;
		{
			Rect toggle12Rect = new Rect( 300, 725 , 100 , 25 ) ;
			GUI.Toggle( toggle12Rect , m_ToggleValue , "toggle12" ) ;	
		}				
	}
}
