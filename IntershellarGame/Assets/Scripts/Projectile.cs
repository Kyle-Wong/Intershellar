using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		//kill enemies
		if(other.CompareTag("Enemy"))
			Destroy(other.gameObject);
		if(!other.CompareTag("Player") && !other.CompareTag("Projectile"))
			Destroy(gameObject);
	}
}
