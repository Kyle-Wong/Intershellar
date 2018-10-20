using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardShellRemove : MonoBehaviour {
    public int shellLossWorth;

    //Change MoveTest to the name of the script with the remove shell method
    public MoveTest removeShell;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Replace AddShell with remove shell method and make shellLossWorth positive
            removeShell.AddShell(-shellLossWorth);
        }
    }
}
