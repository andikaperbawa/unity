using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour 
{
	public int mScore = 0;
	public void Increase()
	{
		mScore++;
	}
	public int getScore()
	{
		return mScore;
	}
}
