using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardShellRemove : MonoBehaviour {
    public int shellLossWorth;
    private ShellStack shellRemover;
    private GameObject removeShell;

	// Use this for initialization
	void Start () {
        removeShell = GameObject.FindGameObjectWithTag("Player");
        shellRemover = GameObject.FindGameObjectWithTag("Player").GetComponent<ShellStack>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < shellLossWorth; i++)
        {
            shellRemover.removeShell();
        }
        removeShell.Lose_Shell();
    }
}
