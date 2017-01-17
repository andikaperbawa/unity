using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManual : DoorBase {
    public float OpenSpeed;

    float m_CurrentOpenDoorFraction;
    float m_TargetOpenDoorFraction;

    protected override void OnUpdate()
    {
        UpdateCurrentOpenDoorFraction();
    }

    void UpdateCurrentOpenDoorFraction()
    {
        m_CurrentOpenDoorFraction = Mathf.MoveTowardsAngle(m_CurrentOpenDoorFraction, m_TargetOpenDoorFraction, OpenSpeed * Time.deltaTime);
    }
    public void OpenDoor()
    {
        m_TargetOpenDoorFraction = 1;
    }
    public void CloseDoor()
    {
        m_TargetOpenDoorFraction = 0;
    }
    protected override float GetDoorOpenFraction()
    {
        return m_CurrentOpenDoorFraction;
    }
}
