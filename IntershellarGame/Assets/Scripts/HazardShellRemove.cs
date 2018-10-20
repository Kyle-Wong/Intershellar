using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardShellRemove : MonoBehaviour {
    public int shellLossWorth;
    private ShellStack shellRemover;
    private Player_Movement removeShell;
    private GameObject player;
    public float forceMagnitude;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        removeShell = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
        shellRemover = GameObject.FindGameObjectWithTag("Player").GetComponent<ShellStack>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Removes a shell from the crab
        for (int i = 0; i < shellLossWorth; i++)
        {
            if (removeShell.Get_ShellCount() > 0)
            {
                shellRemover.removeShell();
                removeShell.Lose_Shell();
            }
        }
        //repulses the player from the hazard
        Vector2 repulsionDirection = -player.transform.position;
        Vector2 repulsionForce = repulsionDirection * forceMagnitude;
        player.transform.GetComponent<Rigidbody2D>().AddForce(repulsionForce);
    }
}
