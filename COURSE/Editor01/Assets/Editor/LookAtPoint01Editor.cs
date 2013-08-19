/**
@file LookAtPoint01Editor.cs
@author NDark
@date 20130819 . file started
*/
using UnityEngine;
using UnityEditor;

// Attention!!! un-mark this line to see the change of m_BallTransform
[CustomEditor (typeof(LookAtPoint01))]
public class LookAtPoint01Editor : Editor {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// change layout of Inspector
    public override void OnInspectorGUI() 
	{
		
		// target is the class of ExecuteInEditMode01
		LookAtPoint01 targetWithType = (LookAtPoint01)target ;
		
        targetWithType.m_TargetPosition = 
			EditorGUILayout.Vector3Field( "Look At Point" , 
										   targetWithType.m_TargetPosition );
		
        if( GUI.changed )
		{
            EditorUtility.SetDirty ( targetWithType );
		}
		//*/
    }		
}
