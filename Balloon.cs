using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent( typeof( Rigidbody ) )]
public class Balloon : MonoBehaviour
{
	Score Score;
	public int HitScore = 0;
	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("CollisionEnter!");
		Increase();
		Debug.Log(getScore());
		//curScore = Score.getScore();
	} 

	void Increase()
	{
		HitScore++;
	}

	int getScore()
	{
		return HitScore;
	}


}
