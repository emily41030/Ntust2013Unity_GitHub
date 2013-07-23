/*
@file OnGUI03.cs
@author NDark
@date 20130722 . file started.
*/
using UnityEngine;

public class OnGUI03 : MonoBehaviour 
{
	public class Piece
	{
		public Rect m_RectNow = new Rect() ;
		public int m_TextureIndex = 0 ;
		public Rect m_TextureCoordinate = new Rect( 0 , 0 , 1.0f , 1.0f ) ;
		public Piece()
		{
			
		}
	}
	
	public int []m_RandomIndex = new int[16] ;
	public Texture m_SpriteTexture = null ;
	public Rect m_RectSize = new Rect( 0 , 0 , 100 , 100 ) ;
	public Rect []m_RectOrg = new Rect[16] ;
	public Piece []m_Pieces = new Piece[16] ;
	
	
	public int m_PickIndex = -1 ;
	

	// Use this for initialization
	void Start () 
	{
		InitializeRandomIndex() ;
		InitializeRect() ;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( true == Input.GetMouseButtonDown( 0 ) )
		{
			for( int j = 0 ; j < 16 ; ++j )
			{
				if( true == m_RectOrg[ j ].Contains( new Vector2( 
					Input.mousePosition.x , 
					Screen.height - Input.mousePosition.y ) ) )
				{
					if( j == m_PickIndex )
					{
						// 放回去
						m_Pieces[ m_PickIndex ].m_RectNow = m_RectOrg[ m_PickIndex ] ;
						m_PickIndex = -1 ;
					}
					else if( -1 == m_PickIndex )
					{
						
						m_PickIndex = j ;
					}
					else
					{
						// 放下並交換
						Rect tmp = new Rect( m_Pieces[ m_PickIndex ].m_TextureCoordinate ) ;
						m_Pieces[ m_PickIndex ].m_TextureCoordinate = m_Pieces[ j ].m_TextureCoordinate ;
						m_Pieces[ j ].m_TextureCoordinate = tmp ;
						m_Pieces[ m_PickIndex ].m_RectNow = m_RectOrg[ m_PickIndex ] ;
						m_PickIndex = -1 ;
					}
					return ;
				}
			}
		}
		
		if( -1 != m_PickIndex )
		{
			m_Pieces[ m_PickIndex ].m_RectNow = 
				new Rect( Input.mousePosition.x - m_Pieces[ m_PickIndex ].m_RectNow.width / 2, 
						  Screen.height - Input.mousePosition.y - m_Pieces[ m_PickIndex ].m_RectNow.height / 2 ,
						  m_Pieces[ m_PickIndex ].m_RectNow.width ,
						  m_Pieces[ m_PickIndex ].m_RectNow.height ) ;
		}		
	}
				
	void OnGUI()
	{
		if( null == m_SpriteTexture )
			return ;
		for( int j = 0 ; j < 16 ; ++j )
		{
			if( j == m_PickIndex )
				continue ;
			
			GUI.DrawTextureWithTexCoords( m_Pieces[ j ].m_RectNow , 
				m_SpriteTexture , 
				m_Pieces[ j ].m_TextureCoordinate ) ;
		}
		
		if( -1 != m_PickIndex )
		{
			GUI.DrawTextureWithTexCoords( m_Pieces[ m_PickIndex ].m_RectNow , 
				m_SpriteTexture , 
				m_Pieces[ m_PickIndex ].m_TextureCoordinate ) ;
		}
		
	}
	
	private void InitializeRandomIndex() 
	{
		for( int i = 0 ; i < 16 ; ++i )
		{
			m_RandomIndex[ i ] = i ;
		}
		
		for( int i = 0 ; i < 16 ; ++i )
		{
			int index1 = Random.Range( 0 , 15 ) ; 
			int index2 = Random.Range( 0 , 15 ) ; 
			int tmp = m_RandomIndex[ index1 ] ;
			m_RandomIndex[ index1 ] = m_RandomIndex[ index2 ]  ;
			m_RandomIndex[ index2 ] = tmp ;
		}
		
	}
	
	private void InitializeRect()
	{
		int index = 0 ;
		for( int j = 0 ; j < 4 ; ++j )
		{
			for( int i = 0 ; i < 4 ; ++i )
			{
				index = j * 4 + i ;
				m_RectOrg[ index ] = new Rect() ;
				m_RectOrg[ index ].Set( m_RectSize.x + i * m_RectSize.width ,
										m_RectSize.y + j * m_RectSize.height ,
										m_RectSize.width ,
										m_RectSize.height ) ;
				m_Pieces[ index ] = new Piece() ;
				m_Pieces[ index ].m_RectNow = new Rect( m_RectOrg[ index ] ) ;
				m_Pieces[ index ].m_TextureIndex = m_RandomIndex[ index ] ;
				m_Pieces[ index ].m_TextureCoordinate = CalculateTexture( m_Pieces[ index ].m_TextureIndex ) ;
			}			
		}
	}
	
	private Rect CalculateTexture( int index )
	{
		int j = index / 4 ;
		int i = index % 4 ;
		return new Rect( i / 4.0f , 1.0f - (j+1) / 4.0f , 1.0f / 4.0f , 1.0f / 4.0f ) ;
	}
}
