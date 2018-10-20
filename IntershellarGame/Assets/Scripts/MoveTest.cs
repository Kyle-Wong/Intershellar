using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour {
    public int shell = 0;
    Transform noShell;
    Transform withShell;
 
	// Use this for initialization
	void Start () {
        noShell = transform.Find("NoShellImage");
        withShell = transform.Find("WithShellImage");
	}
	
	// Update is called once per frame
	void Update () {
        if (shell > 0)
        {
            withShell.gameObject.SetActive(true);
            noShell.gameObject.SetActive(false);
        }else
        {
            withShell.gameObject.SetActive(false);
            noShell.gameObject.SetActive(true);
        }
        transform.Translate(.1f, 0, 0);
	}

    public void AddShell(int worth)
    {
        shell = shell + worth;
    }
}
