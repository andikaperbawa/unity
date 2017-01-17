using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myfirstscript : MonoBehaviour {
    public int Repeats;
    public string Text;
    public float FloatVar;
    public bool IsPrinting;
    public Vector2 Direction;
     
	// Use this for initialization
	void Start () {
        for (int i=0; i<Repeats;i++)

        Debug.Log("Hi KAUST");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
