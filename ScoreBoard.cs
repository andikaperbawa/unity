using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent( typeof( Text ) )]
public class ScoreBoard : MonoBehaviour 
{
    public PaddleScore PaddleScore;

    Text m_Text;

    void Awake()
    {
        m_Text = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        m_Text.text = PaddleScore.GetScore().ToString();
	}
}
