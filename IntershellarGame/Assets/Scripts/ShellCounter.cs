using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShellCounter : MonoBehaviour {

    // Use this for initialization
    private Player_Movement player;
    private Text text;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Shells you kept: " + player.shellCount;
    }
}
