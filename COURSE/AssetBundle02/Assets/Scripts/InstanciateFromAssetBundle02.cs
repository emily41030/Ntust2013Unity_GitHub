using UnityEngine;
using System.Collections;

public class InstanciateFromAssetBundle02 : MonoBehaviour 
{
	public string m_PrefabName = "" ;
	public string m_ObjectName = "" ;
	
	LoadAssetBundle01 m_LoadAssetBundle = null ;
	// Use this for initialization
	void Start () 
	{
		m_LoadAssetBundle = this.gameObject.GetComponent<LoadAssetBundle01>() ;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		GUILayout.TextArea( m_PrefabName ) ;
		GUILayout.TextArea( m_ObjectName ) ;
		if( true == GUILayout.Button( "Instanciate" ) )
		{
			Object prefab = m_LoadAssetBundle.m_AssetBundle.Load( m_PrefabName ) ;
			if( null == prefab )
				return ;
			GameObject gameObj = (GameObject) GameObject.Instantiate( prefab ) ;
			
			if( null != gameObj )
			{
				gameObj.name = m_ObjectName ;
				gameObj.AddComponent<Rigidbody>() ;
				gameObj.rigidbody.AddForce( Random.onUnitSphere ) ;
			}
		}
	}
}
