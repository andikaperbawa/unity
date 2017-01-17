using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class KiteControls : NVRInteractableItem {
	public float ropeReleaseSpeed;
	public float UpliftSpeed;
	public float FallingSpeed;
	public float RotationAngleSpeed;

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

			m_Transform.position += GetKiteDirection(m_Transform,ropeHolder)*ropeReleaseSpeed*ropeHolder.Inputs [NVRButtons.Touchpad].Axis.y;  //PULL AND PUSH
			if (ropeHolder.Inputs [NVRButtons.Touchpad].Axis.y > 0.0f) 
			{
				m_Transform.position -= new Vector3 (0f, FallingSpeed, 0f);
			}
				

			float triggerDistance = ropeHolder.Inputs [NVRButtons.Trigger].SingleAxis * UpliftSpeed;											// TRIGGER BUTTO


			if (ropeHolder.UseButtonDown) 
			{
				m_Transform.LookAt (ropeHolder.CurrentPosition);
				NVRHead PlayerHead = ropeHolder.GetComponentInParent<NVRHead> ();
				Vector3 HandRelHeadVector = ropeHolder.CurrentPosition - PlayerHead.transform.position;
				m_Transform.Rotate(0.0f,0.0f,HandRelHeadVector.x*RotationAngleSpeed*30,Space.Self);
				m_Transform.localPosition+=new Vector3(0f,triggerDistance,0f);

			}
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
	void UpdateUseButtonOffMotion(NVRHand ropeHolder) 													// ROTATE THE KITE
	{
		m_Transform.LookAt (ropeHolder.CurrentPosition);
		NVRHead PlayerHead = ropeHolder.GetComponentInParent<NVRHead> ();
		Vector3 HandRelHeadVector = ropeHolder.CurrentPosition - PlayerHead.transform.position;
		m_Transform.Rotate(0.0f,0.0f,HandRelHeadVector.x*RotationAngleSpeed*30,Space.Self);
		m_Transform.localPosition+=new Vector3(HandRelHeadVector.x*RotationAngleSpeed,0f,0f);
	}
}
