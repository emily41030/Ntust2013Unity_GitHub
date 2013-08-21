/*
@file ExportSelectScene01.cs
@author NDark
@date 20130821 file started.
*/
using UnityEngine;
using UnityEditor;
using System.IO ; // for path


public class ExportSelectScene01 : MonoBehaviour 
{
	
	[MenuItem ("Build/BuildScenesFromTarget")]
	static void BuildTargetScenesToAssetBundle()
	{
		string []levels = {
			"Assets/Scenes/Test.unity"
		} ;
		
		string fileName = Path.GetFileName( levels[0] ) ;
		BuildPipeline.BuildStreamedSceneAssetBundle( 
			levels, 
			"TargetScenes_" + fileName + ".unity3d", 
			BuildTarget.StandaloneWindows ) ; 
		
		Debug.Log( "BuildOpenFilePanelToAssetBundle() completed. levels=" + levels ) ;
	}
	
	
	[MenuItem ("Build/BuildSceneFromOpenFilePanel")]
	static void BuildOpenFilePanelToAssetBundle()
	{
		string selectedFile = EditorUtility.OpenFilePanel( "File to Asset Bundle" , "Assets" , ".unity" ) ;
		if( 0 == selectedFile.Length )
			return ;
		
		string []levels = null ;
		string ext = Path.GetExtension( selectedFile ) ;
		if( ".unity" == ext.ToLower() )
		{
			levels = new string[1] ;
			levels[ 0 ] = selectedFile ;
		}
		
		string fileName = Path.GetFileName( levels[0] ) ;
		BuildPipeline.BuildStreamedSceneAssetBundle( 
			levels, 
			"TargetScenes_" + fileName + ".unity3d",			
			BuildTarget.StandaloneWindows ) ; 
		
		Debug.Log( "BuildOpenFilePanelToAssetBundle() completed. levels=" + levels ) ;
	}
	
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
