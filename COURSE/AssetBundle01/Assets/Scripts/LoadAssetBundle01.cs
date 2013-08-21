/*
@file LoadAssetBundle01.cs
@author NDark
@date 20130821 file started.
*/
using UnityEngine;

public class LoadAssetBundle01 : MonoBehaviour 
{
	public AssetBundle m_AssetBundle = null ;
	public string m_Unity3DURL = "file:///"
		+ "D:/Workspace/Project/Ntust2013Unity/COURSE/AssetBundle01/" 
		+ "BuildAssetBundle.unity3d" ;
	
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
			
			// Try mark this line
			m_AssetBundle = download.assetBundle;
			
			if( null == m_AssetBundle )
			{
				Debug.Log( "null == assetBundle" ) ;
			}
			else
			{
				Debug.Log( "null != assetBundle" ) ;
				Object[] objs = m_AssetBundle.LoadAll() ;
				foreach( Object obj in objs )
				{
					Debug.Log( obj.name ) ;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
