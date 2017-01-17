using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingkite : kitebase {
	protected override float GetKiteLevitate()
	{
		return Mathf.Sin(Time.timeSinceLevelLoad);
	}
}