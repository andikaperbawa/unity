using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAutomatic : DoorBase {
    protected override float GetDoorOpenFraction()
    {
        return Mathf.Clamp01(Mathf.Sin(Time.timeSinceLevelLoad));
    }
}
