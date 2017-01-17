using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour 
{
    public BallMovement Ball;
    public PaddleScore PaddleScore;

    void OnCollisionEnter2D( Collision2D collision )
    {
        PaddleScore.IncrementScore();
        Ball.ResetBall();
    }
}
