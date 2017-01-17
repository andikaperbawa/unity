using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class kitebase : MonoBehaviour {
	public float levitation;
	protected Transform m_Transform;

	// Use this for initialization
	void Awake()
	{
		m_Transform = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update()
	{
		float elevation = GetKiteLevitate()*levitation;

		m_Transform.localPosition += new Vector3 (0, elevation, 0);

		m_Transform.localRotation = Quaternion.Euler (0, Random.Range (-20, 20)*Time.deltaTime*5, 0);
		
			OnUpdate();
	}

	protected abstract float GetKiteLevitate();
	protected virtual void OnUpdate ()
	{
	}
}