﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellPickUp : MonoBehaviour {
    //Change MoveTest to name of script with GainShell() method
    private Player_Movement shellAdder;
    public bool randomizeSprite = true;
    public int worth;
    [HideInInspector]
    public int shellType = -1;
    public float pickupDelay = 0;
	// Use this for initialization
	void Start () {
        shellAdder = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
        if (randomizeSprite)
        {
            ShellList shellList = GameObject.FindGameObjectWithTag("ShellData").GetComponent<ShellList>();
            shellType = (int)Random.Range(0, shellList.shellSprite.Length);
            GetComponent<SpriteRenderer>().sprite = shellList.shellSprite[shellType];
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(pickupDelay > 0)
            pickupDelay -= Time.deltaTime;
	}

    //Detects if the player collides with the shell
    void OnTriggerEnter2D(Collider2D other)
    {
        if(pickupDelay > 0)
        {
            return;
        }
        //adds shells to crab
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            shellAdder.Gain_Shell(worth,shellType);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (pickupDelay > 0)
        {
            return;
        }
        //adds shells to crab
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            shellAdder.Gain_Shell(worth, shellType);
        }
    }
}
