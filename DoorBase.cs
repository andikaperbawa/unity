using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DoorBase : MonoBehaviour {
    public float OpenAngle;
    protected Transform m_Transform;

    // Use this for initialization
    void Awake()
    {
        m_Transform = GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update()
    {
        float angle = GetDoorOpenFraction()*OpenAngle;

        m_Transform.localRotation = Quaternion.Euler(0, angle, 0);
        OnUpdate();
    }

    protected abstract float GetDoorOpenFraction();
    protected virtual void OnUpdate()
    {

    }
}
