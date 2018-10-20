using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {
    private ShellStack stacking = new ShellStack();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
    void NoShells()
    {
        if (stacking.shellCount() == 0)
        {

        }
    }
}
