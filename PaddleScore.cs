using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScore : MonoBehaviour 
{
    int m_Score = 0;

    public void IncrementScore()
    {
        m_Score++;
    }

    public int GetScore()
    {
        return m_Score;
    }
}
