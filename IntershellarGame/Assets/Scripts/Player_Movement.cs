﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public Transform shellProjectilePrefab;
    private ShellStack stacker;
    private Vector3 velocity;
    float crab_speed = 1f;
    float rotation_speed = 10f;
    public float drag;
    public float playerLeapVelocity;
    public float shellShotSpeed;
    public int shellCount;
	// Use this for initialization
	void Start () {
        velocity = new Vector3(0, 0, 0);
        stacker = GetComponent<ShellStack>();
        Gain_Shell(shellCount);
	}
	
	// Update is called once per frame
	void Update () {
        /*
        float rotating = Input.GetAxis("Rotation") * rotation_speed;
        if (Input.GetButton("Rotation"))
        {
            transform.Rotate(0, 0, rotating);
        }
        */
        transform.position += velocity * Time.deltaTime;
        velocity *= drag;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotation_speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -rotation_speed);
        }
        if (Input.GetKeyDown(KeyCode.W) && shellCount > 0)
            ShootShell();
        /*if (Input.GetButtonDown("Push"))
        {
            transform.Translate
        }*/
    }
    //Activates when crab collides with detached shell. Places shell on top of stack.
    public void Gain_Shell(int worth)
    {
        for (int i = 0; i < worth; i++)
        {
            stacker.addShell();
        }
        shellCount += worth;
    }
    public Vector3 getVelocity()
    {
        return velocity;
    }
    public void setVelocity(Vector3 v)
    {
        velocity = v;
    }
    private void ShootShell()
    {
        //if has shell...

        //calculate the direction of the player
        shellCount--;
        Vector3 playerDir = transform.up*-1;
        //project shell
        Transform shellObject = Instantiate(shellProjectilePrefab, transform.position, Quaternion.LookRotation(transform.forward,playerDir));
        shellObject.GetComponent<Projectile>().setVelocity(-1 * playerDir * shellShotSpeed);
        velocity = playerDir * playerLeapVelocity;
        stacker.removeShell();
        //dash self
        
    }
}
