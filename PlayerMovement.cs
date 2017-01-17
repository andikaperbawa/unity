using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(NavMeshAgent)]
public class PlayerMovement : MonoBehaviour {
	public float Speed;
	public float TurnSpeed;
	public KeyCode UpKey;
	public KeyCode DownKey;
	NavMeshAgent m_Agent;
	Transform m_Transform;
	void Awake()
	{
		m_Agent = GetComponent<NavMeshAgent>();
		m_Transform = GetComponent<Transform>();
	}
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log(Input.GetAxis("Vertical"));
		m_Transform.Rotate(0, TurnSpeed * Time.deltaTime* Input.GetAxis("Horizontal"),0);
		
		m_Agent.Move(m_Transform.forward * Time.deltaTime * Speed * Input.GetAxis("Vertical"));
		//m_Transform.Translate(m_Transform.position + Vector3.up*  Time.deltaTime*Input.GetAxis("Fire1")*Speed);
		//m_Transform.Translate(m_Transform.position + Vector3.down*Time.deltaTime*Input.GetAxis("Fire2")*Speed);
		//m_Agent.Move(m_Transform.up * Time.deltaTime * Speed * Input.GetKey(UpKey));
		//m_Agent.Move(-1 * m_Transform.up * Time.deltaTime * Speed * Input.GetKey(DownKey));
		
		
		
		
		//m_Transform.Up(0, TurnSpeed * Time.deltaTime* Input.GetAxis("Horizontal"),0);

		//m_Transform.Rotate(0, TurnSpeed * Time.deltaTime* Input.GetAxis("Horizontal"),0);
		//m_Agent.Move(m_Transform.forward * Time.deltaTime * Speed * Input.GetAxis("Vertical"));
		//m_Agent.Move(m_Transform.forward * Time.deltaTime * Speed * Vector2(0.1f,0.2f));

	}
	void FixedUpdate()
	{
		if (Input.GetKey(UpKey) == true)
		{
			Debug.Log(m_Transform.up * Time.deltaTime * Speed );
			m_Transform.position += new Vector3(0,10,0);
			//m_Agent.Move(m_Transform.up * Time.deltaTime * Speed );
			//m_Transform.Translate(m_Transform.position + m_Transform.up * Time.deltaTime * Speed);
		}
		else if (Input.GetKey(DownKey) == true)
		{
			Debug.Log(-1 * m_Transform.up * Time.deltaTime * Speed);
			//m_Agent.Move(-1 * m_Transform.up * Time.deltaTime * Speed);
			m_Transform.position -= new Vector3(0,-5,0);
			//m_Transform.Translate(m_Transform.position - m_Transform.up * Time.deltaTime * Speed);
		}
	}
}
