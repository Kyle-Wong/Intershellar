using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellPickUp : MonoBehaviour {
    //Change MoveTest to name of script with GainShell() method
    private Player_Movement shellAdder;
    public int worth;

	// Use this for initialization
	void Start () {
        shellAdder = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Detects if the player collides with the shell
    void OnTriggerEnter2D(Collider2D other)
    {
        //adds shells to crab
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            shellAdder.Gain_Shell(worth);
        }
    }
}
