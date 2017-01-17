using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class AdvancedKiteController : NVRInteractableItem 
{
	public float UpliftSpeed;
	public float RopeReleaseSpeed;
	public float FallingSpeed;
	Transform m_kiteTransform;


	float TurbulenceLength;
	float RotationAngle=60.0f;
	NVRHand RopeHolder;
	bool IsKiteFlying;
	bool InitialThrow;
	protected override void Awake ()
	{
		base.Awake ();
		m_kiteTransform = GetComponent<Transform> ();
	}

	public override void BeginInteraction (NVRHand hand)
	{
		base.BeginInteraction (hand);
		RopeHolder = hand;

	}

	public override void EndInteraction ()
	{
		base.EndInteraction ();
		IsKiteFlying = true;
		InitialThrow = true;
	}

	protected override void FixedUpdate ()
	{
		
		base.FixedUpdate ();
		if (RopeHolder != null)
		{
			

			TurbulenceLength = 0.2f;
			if (IsKiteFlying) 
			{
				if (RopeHolder.Inputs [NVRButtons.Grip].IsPressed)
				{
					kitePropel (RopeHolder);	
				} 
				else 
				{
					kiteFloat (RopeHolder);	
				}
			}
		}
	}

	bool IsKiteFar(Transform kiteTransform, NVRHand ropeHolder)
	{	
		Vector3 kitePositionFromHand = m_kiteTransform.position - ropeHolder.CurrentPosition;
		return (Vector3.Magnitude(kitePositionFromHand)>0.5f);
	}

	bool IsKiteNearGround(Transform kiteTransform)
	{
		return (kiteTransform.position.y < 4.0f);
	}

	void kiteFloat(NVRHand hand)
	{
		m_kiteTransform.LookAt (hand.CurrentPosition);
		float angle = Mathf.Sin (Time.timeSinceLevelLoad) *RotationAngle ;
		m_kiteTransform.Rotate (0, angle, 0, Space.Self);
		m_kiteTransform.localPosition += new Vector3(Mathf.Sin(Time.timeSinceLevelLoad)*TurbulenceLength,Mathf.Sin(Time.timeSinceLevelLoad)*TurbulenceLength,0);
		m_kiteTransform.position += GetKiteDirection(m_kiteTransform,RopeHolder)*RopeReleaseSpeed*RopeHolder.Inputs [NVRButtons.Touchpad].Axis.y;
		if (hand.Inputs [NVRButtons.Touchpad].Axis.y > 0.0f) 
		{
			m_kiteTransform.position -= new Vector3 (0f, FallingSpeed, 0f);
		}
	}

	void kitePropel(NVRHand hand)
	{
		m_kiteTransform.position+=hand.GetPositionDelta() *10* UpliftSpeed;
		m_kiteTransform.LookAt (hand.CurrentPosition);
		m_kiteTransform.Rotate (0, 0, -hand.transform.forward.x*180, Space.Self);
		m_kiteTransform.localPosition += new Vector3(0,hand.Inputs [NVRButtons.Trigger].SingleAxis * UpliftSpeed,0);
		m_kiteTransform.position += GetKiteDirection(m_kiteTransform,RopeHolder)*RopeReleaseSpeed*RopeHolder.Inputs [NVRButtons.Touchpad].Axis.y;
		if (hand.Inputs [NVRButtons.Touchpad].Axis.y > 0.0f) 
		{
			m_kiteTransform.position -= new Vector3 (0f, FallingSpeed, 0f);
		}
	}

	Vector3 GetKiteDirection(Transform kiteTransform, NVRHand ropeHolder)
	{
		Vector3 kitePositionFromHand = m_kiteTransform.position - ropeHolder.CurrentPosition;
		return Vector3.Normalize (kitePositionFromHand);
	}
}