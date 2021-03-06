﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardShellRemove : MonoBehaviour {
    public int shellLossWorth;
    private ShellStack shellRemover;
    private Player_Movement movement;
    private GameObject player;
    private float forceConstant;
    private float timer = .5f;
    private float timing;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
        shellRemover = GameObject.FindGameObjectWithTag("Player").GetComponent<ShellStack>();
        timing = 0;
        forceConstant = 200;
	}
	
	// Update is called once per frame
	void Update () {

        clock();
		
	}

    void clock()
    {
        if (timing > 0)
        {
            timing -= Time.deltaTime;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (timing <= 0)
            {
                //Removes a shell from the crab
                for (int i = 0; i < shellLossWorth; i++)
                {
                    if (movement.shellCount > 0)
                    {
                        movement.spawnLooseShell();
                        movement.Lose_Shell();
                    }
                }
                timing = timer;
            }

            //repulses the player from the hazard
            Vector2 repulsionDirection = -(transform.position - movement.transform.position);
            Vector2 repulsionForce = repulsionDirection * forceConstant;
            player.transform.GetComponent<Rigidbody2D>().AddForce(repulsionForce * 2);
            Debug.Log(repulsionForce);
        }
    }
}
