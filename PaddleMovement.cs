using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( Rigidbody2D ) )]
public class PaddleMovement : MonoBehaviour 
{
    public float Speed;
    public KeyCode UpKey;
    public KeyCode DownKey;

    Rigidbody2D m_Body;

    void Awake()
    {
        m_Body = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if( Input.GetKey( UpKey ) == true )
        {
            MovePaddle( Speed );
        }
        else if( Input.GetKey( DownKey ) == true )
        {
            MovePaddle( -Speed );
        }
	}

    void MovePaddle( float yDirection )
    {
        Vector2 newPosition = m_Body.position + new Vector2( 0, yDirection );

        m_Body.MovePosition( newPosition );
    }
}
