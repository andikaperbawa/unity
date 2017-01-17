using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( Rigidbody2D ) )]
public class BallMovement : MonoBehaviour {
    public float InitialSpeed;
    public ForceMode2D ForceMode;

    Rigidbody2D m_Body;
    Transform m_Transform;

    bool m_IsResting = false;

    void Awake()
    {
        m_Body = GetComponent<Rigidbody2D>();
        m_Transform = GetComponent<Transform>();
    }

	// Use this for initialization
	void Start () 
    {
        ResetBall();
	}
	
    void FixedUpdate()
    {
        
    }
   
	// Update is called once per frame
	void Update () {
        if( Input.anyKeyDown == true )
        {
            ApplyInitialVelocity();
        }

        //m_Transform.Translate( new Vector3( 1000, 0, 0 ) * Time.deltaTime );

        //100fps
        //deltaTime = 1 / 100
        //m_Transform.Translate( new Vector3( 10, 0, 0 ) );
        //new Vector3( 1000, 0, 0 )


        //10fps
        //deltaTime = 1 / 10
        //m_Transform.Translate( new Vector3( 100, 0, 0 ) );
	}

    void ApplyInitialVelocity()
    {
        if( m_IsResting == false )
        {
            return;
        }

        m_IsResting = false;

        Vector2 randomDirection = new Vector2( Random.Range( -1f, 1f ), Random.Range( -1f, 1f ) );

        if( randomDirection.x == 0 )
        {
            randomDirection.x = 1;
        }

        randomDirection.Normalize();

        m_Body.velocity = randomDirection * InitialSpeed;
    }

    public void ResetBall()
    {
        m_Body.MovePosition( Vector2.zero );
        m_IsResting = true;
        m_Body.velocity = Vector2.zero;
    }
}
