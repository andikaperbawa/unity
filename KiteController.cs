using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class KiteController : NVRInteractableItem {
	public float ropeReleaseSpeed;
	public float UpliftSpeed;
	public float FallingSpeed;
	public float RotationAngleLimit;

	bool isKiteFlying;

	Transform m_Transform;
	NVRHand ropeHolder;  

	protected override void Awake()
	{
		base.Awake ();
		m_Transform = GetComponent<Transform> ();
	}

	public override void BeginInteraction (NVRHand hand)
	{
		ropeHolder = hand;
		base.BeginInteraction (hand);
	}

	public override void EndInteraction ()
	{
		isKiteFlying = true;
		base.EndInteraction ();
	}
	protected override void FixedUpdate()
	{
		base.FixedUpdate ();
		if (ropeHolder != null) 
		{
			if (Vector3.Magnitude (ropeHolder.GetPositionDelta ()) != 0.0f) 
			{
				Debug.Log (ropeHolder.GetPositionDelta());
			}

			if (isKiteFlying) 
			{
				//RandomRotator (m_Transform, Random.Range (1000, 3000));
			}

			m_Transform.position += GetKiteDirection(m_Transform,ropeHolder)*ropeReleaseSpeed*ropeHolder.Inputs [NVRButtons.Touchpad].Axis.y;


			float triggerDistance = ropeHolder.Inputs [NVRButtons.Trigger].SingleAxis * UpliftSpeed;
			if (ropeHolder.Inputs [NVRButtons.Touchpad].Axis.y > 0.0f) 
			{
				m_Transform.position -= new Vector3 (0f, FallingSpeed, 0f);
			}


			m_Transform.position+=new Vector3(0f,triggerDistance,0f);

			if (ropeHolder.UseButtonDown) 
			{
				m_Transform.LookAt (ropeHolder.CurrentPosition);

				//m_Transform.localPosition += new Vector3(0f, triggerDistance/Mathf.Sqrt(2), triggerDistance/Mathf.Sqrt(2));
			}
		}
	}

	void RandomRotator(Transform trans, int timer)
	{
		float rotationAngle = Random.Range (-RotationAngleLimit, RotationAngleLimit);
		for(int i=0; i<timer; i++)
		{
			trans.Rotate (0, rotationAngle / timer, 0, Space.Self);
		}
	}

	Vector3 GetKiteDirection(Transform kiteTransform, NVRHand ropeHolder)
	{
		Vector3 kitePositionFromHand = m_Transform.position - ropeHolder.CurrentPosition;
		return Vector3.Normalize (kitePositionFromHand);
	}

	bool isFar(Transform kiteTransform, NVRHand ropeHolder)
	{
		Vector3 kitePositionFromHand = m_Transform.position - ropeHolder.CurrentPosition;
		return (Vector3.Magnitude (kitePositionFromHand) > 2.0f);
	}
}
