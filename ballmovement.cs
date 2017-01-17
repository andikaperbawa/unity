using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ballmovement : MonoBehaviour {
    public Vector2 InitialForce;
    public ForceMode2D ForceMode;

    Rigidbody2D m_Body;
    Transform m_Transform;

    void Awake()
    {
        m_Body = GetComponent<Rigidbody2D>();
        m_Transform = GetComponent<Transform>();

    }
    // Use this for initialization
    void Start() {
        //  m_Body = GetComponent<Rigidbody2D>();
        m_Body.AddForce(InitialForce, ForceMode2D.Impulse);
    }
    void FixedUpdate()
    {
       // m_Body.AddForce(InitialForce*Time.fixedDeltaTime, ForceMode2D.Impulse);
    }
    // Update is called once per frame
    void Update () {
        //m_Transform.Translate (new Vector3(10, 0, 0) * Time.deltaTime);

        //100fps
        //deltaTime=1/100
        //m_Transform.Translate(new Vector3(10, 0, 0));
        //new Vector3 (1000,0,0)

        //10fps
        //deltaTime=1/10
        //m_Transform.Translate(new Vector3(100, 0, 0));

        public void ResetBall()
    {
        m_Body.MovePosition(Vector2.zero);
        m_Body.velocity = new Vector2(Random.Range(-1, 1));
    }
    }
}
