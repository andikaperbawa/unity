using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManualProximityTrigger : MonoBehaviour {
    DoorManual m_Door;

    void Awake()
    {
        m_Door = GetComponent<DoorManual>();
    } 
    void OnTriggerEnter(Collider collider)
    {
        m_Door.OpenDoor();
    }

    void OnTriggerExit(Collider collider)
    {
        m_Door.CloseDoor();
    }
}
