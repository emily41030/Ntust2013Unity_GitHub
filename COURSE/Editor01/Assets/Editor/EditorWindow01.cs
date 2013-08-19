/*
@file EditorWindow01.cs
@author NDark

Attention!!!!
Script must be placed in the folder called "Editor" in Assets

@date 20130819 file started.
*/
using UnityEngine;
using UnityEditor ; // add this for editor
	
// You don't have to put script on GameObject
public class EditorWindow01 : EditorWindow 
{
	[MenuItem ("Window/My Window")]
    static void ShowWindow () 
	{
        EditorWindow.GetWindow<EditorWindow01>() ;
    }		

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	string myString = "Hello World";
	bool groupEnabled;
	bool myBool = true;
	float myFloat = 1.23f;
	// public Rect m_Rect1 = new Rect( 100 , 100 , 200 , 100 ) ;
	
	// the content of your window draw here.
	void OnGUI()
	{
		
		
		
		myString = EditorGUILayout.TextField ("Text Field", myString);
		/*
		groupEnabled = EditorGUILayout.BeginToggleGroup ("Optional Settings", groupEnabled);
			myBool = EditorGUILayout.Toggle ("Toggle", myBool);
			myFloat = EditorGUILayout.Slider ("Slider", myFloat, -3, 3);
		EditorGUILayout.EndToggleGroup ();
		*/
	}

}
