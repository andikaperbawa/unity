using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManualKeyboardDebug : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.O))
        {
            GetComponent<DoorManual>().OpenDoor();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            GetComponent<DoorManual>().CloseDoor();
        }
	}
}
