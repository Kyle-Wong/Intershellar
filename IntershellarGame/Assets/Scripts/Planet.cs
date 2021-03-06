﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {
	private GameObject player;
	public float circleAroundRadius; //the radius when to start circle around
	public float rangeRadius; //the radius of the range circle
	public float force;
	public float perpendicularForce;
	public float maxSpeed;
    private bool inRange;
    private AudioSource source;
    private float volume;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, rangeRadius);
		Gizmos.DrawWireSphere(transform.position, circleAroundRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, player.transform.position);
        Gizmos.color = Color.green;
        Vector2 orthoVector = Vector2.Perpendicular(transform.position - player.transform.position);
        Gizmos.DrawLine(player.transform.position, player.transform.position + (Vector3)orthoVector);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(player.transform.position, player.transform.position + (Vector3)player.GetComponent<Rigidbody2D>().velocity);
    }

    // Update is called once per frame
    void Update () {
        //player.GetComponent<Rigidbody2D>().velocity *= 0.99f;
        //attract player if in range
        if (Vector2.Distance(transform.position, player.transform.position) <= rangeRadius)
        {
            float distance = (transform.position - player.transform.position).magnitude;
            source.volume = Mathf.Lerp(.75f, 0, (distance - circleAroundRadius) / (rangeRadius - circleAroundRadius));
            if (!inRange)
                source.Play();
            
            inRange = true;
            Attract();
        } else
        {
            inRange = false;
        }
	}

	private void Attract()
	{
		//get the direction towards player
		Vector2 attractDirection = transform.position - player.transform.position;
		//make its size to 1
		float attractDistance = Mathf.Sqrt(attractDirection.x *attractDirection.x + attractDirection.y * attractDirection.y);
		attractDirection/= attractDistance;
		//closer to planet, stronger the force
		Vector2 attractVector = attractDirection * force* ((rangeRadius - attractDistance)/rangeRadius);
		//check maxSpeed
		if(Mathf.Sqrt(attractVector.x *attractVector.x + attractVector.y * attractVector.y) > maxSpeed)
		{
			attractVector = attractDirection * maxSpeed;
		}
		//circle around
		if(Vector2.Distance(transform.position, player.transform.position) <= circleAroundRadius)
		{
			attractVector = new Vector2(0,0);
		}
       
        Vector2 ccVector = Vector2.Perpendicular(transform.position - player.transform.position);
        Vector2 cVector = Vector2.Perpendicular(player.transform.position - transform.position);
        Vector2 perpendicularVector = new Vector2();
        float angleBetween1 = Vector2.Angle(player.GetComponent<Rigidbody2D>().velocity, ccVector);
        float angleBetween2 = Vector2.Angle(player.GetComponent<Rigidbody2D>().velocity, cVector);
        if(angleBetween1 < 90)
        {
            perpendicularVector = ccVector.normalized* perpendicularForce;
        } else if(angleBetween2 < 90)
        {
            perpendicularVector = cVector.normalized * perpendicularForce;

        }
        //finally, attract
        player.transform.GetComponent<Rigidbody2D>().AddForce(attractVector * Time.deltaTime * 60,ForceMode2D.Force);
		player.transform.GetComponent<Rigidbody2D>().AddForce(perpendicularVector * Time.deltaTime * 60 ,ForceMode2D.Force);
		

	}

}
