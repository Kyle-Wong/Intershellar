using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wormhole : MonoBehaviour {
	public GameObject winUI;
	public Text shellNumberText;
	void Start()
	{
		winUI.SetActive(false);
	}
	// Use this for initialization
	public void OnTriggerEnter2D(Collider2D other)
	{
		//player touches the wormhole, success
		if(other.CompareTag("Player"))
		{
			winUI.SetActive(true);
			Time.timeScale = 0;
			//maybe modify the info in the UI
			shellNumberText.text = "Shells you kept: " + GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().shellCount.ToString();
		}
	}

}
