﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellPickUp : MonoBehaviour {
    //Change MoveTest to name of script with GainShell() method
    public MoveTest shellAdder;
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
            shellAdder.AddShell(worth);

            //Actual method to gain shell below
            //shellAdder.GainShell(worth);
        }
        Debug.Log("Hit");
    }
}
