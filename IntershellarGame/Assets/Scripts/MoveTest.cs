using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour {
    public int shell = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(.5f, 0, 0);
	}

    public void AddShell()
    {
        shell = shell + 1;
    }
}
