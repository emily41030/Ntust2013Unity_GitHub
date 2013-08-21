/*
@file InstanciateFromAssetBundle01.cs
@author NDark
@date 20130821 file started.
*/
using UnityEngine;

public class InstanciateFromAssetBundle01 : MonoBehaviour 
{
	public string m_Unity3DURL = "file:///"
		+ "D:/Workspace/Project/Ntust2013Unity/COURSE/AssetBundle01/" 
		+ "BuildAssetBundle.unity3d" ;
	
	public string m_PrefabName = "Cube" ;
	// Use this for initialization
	void Start () 
	{
		WWW download = WWW.LoadFromCacheOrDownload( m_Unity3DURL , 0 ) ;
		if( null == download )
		{
			Debug.LogError( "null == download" ) ;
		}
		else
		{
			
            AssetBundle assetBundle = null ;
			
			// Try mark this line
			assetBundle = download.assetBundle;
			
			if( null == assetBundle )
			{
				Debug.Log( "null == assetBundle" ) ;
			}
			else
			{
				Debug.Log( "null != assetBundle" ) ;
					
				Object prefab = assetBundle.Load( m_PrefabName ) ;
				if( null == prefab )
				{
					Debug.Log( "null == prefab" ) ;
				}
				else
				{
					GameObject obj = (GameObject) GameObject.Instantiate( prefab ) ;
					obj.name = "NewCube" ;
				}
			}	
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
