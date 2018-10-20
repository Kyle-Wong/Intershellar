using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {
	public GameObject player;
	public float circleAroundRadius; //the radius when to start circle around
	public float rangeRadius; //the radius of the range circle
	public float force;
	public float perpendicularForce;
	public float maxSpeed;

	// Use this for initialization
	void Start () {
		
	}
	void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, rangeRadius);
		Gizmos.DrawWireSphere(transform.position, circleAroundRadius);
    }

	// Update is called once per frame
	void Update () {
		//player.GetComponent<Rigidbody2D>().velocity *= 0.99f;
		//attract player if in range
		if(Vector2.Distance(transform.position, player.transform.position) <= rangeRadius)
			Attract();
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
		//finally, attract
		player.transform.GetComponent<Rigidbody2D>().AddForce(attractVector * Time.deltaTime * 60,ForceMode2D.Force);
		Vector2 perpendicularVector = new Vector2(attractDirection.y, - attractDirection.x) * perpendicularForce;
		player.transform.GetComponent<Rigidbody2D>().AddForce(perpendicularVector * Time.deltaTime * 60 ,ForceMode2D.Force);
		

	}

}
