﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour {
	private GameObject player;
	public int initialRotation;
	[Header("Bullet")]
	public GameObject bullet;
	private float timer;
	public float shootInterval;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		FacePlayer();
		CheckShoot();
		timer += Time.deltaTime;
		
	}

	//rotate the enemy to face the player
	private void FacePlayer()
	{
		 
		//turn left or right?
		//if()
		Vector2 differ = player.transform.position - transform.position;
		float rotation = Mathf.Atan2(differ.y, differ.x) * Mathf.Rad2Deg;
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rotation + initialRotation);
	}

	private void CheckShoot()
	{
		if(Vector2.Distance(transform.position, player.transform.position) < 5)
		{
			if(timer > shootInterval)
			{
				timer = 0;
				GameObject bulletObject = GameObject.Instantiate(bullet, transform.Find("mouse").position, Quaternion.identity);
				bulletObject.GetComponent<EnemyBullet>().SetVelocity(transform.rotation.eulerAngles.z);
			}
		}
	}

}