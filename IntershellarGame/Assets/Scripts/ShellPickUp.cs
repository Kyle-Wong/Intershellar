using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellPickUp : MonoBehaviour {

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
        }
        Debug.Log("Hit");
    }
}
