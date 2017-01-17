using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoHitBall : MonoBehaviour {

	Transform m_Transform;
	void Awake()
	{
		m_Transform = GetComponent<Transform>();
	}
	// Use this for initialization
	void Start () 
	{
		m_Transform.Translate(8*Vector3.up);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
