﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellPickUp : MonoBehaviour {
    //Change MoveTest to name of script with GainShell() method
    public MoveTest shellAdder2;
    public Player_Movement shellAdder;
    public int worth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Detects if the player collides with the shell
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            
            //Delete this
            shellAdder2.AddShell(worth);
            Debug.Log("GotShell");

            //Uncomment when Gain Thing
            //shellAdder.Gain_Shell(worth);
        }
        Debug.Log("Hit");
    }
}
