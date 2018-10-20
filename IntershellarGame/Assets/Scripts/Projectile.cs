using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    // Use this for initialization
    private Vector3 velocity;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += velocity * Time.deltaTime;
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		//kill enemies
		if(other.CompareTag("Enemy"))
			Destroy(other.gameObject);
		if(!other.CompareTag("Player") && !other.CompareTag("Projectile"))
			Destroy(gameObject);
	}
    public void setVelocity(Vector3 v)
    {
        velocity = v;
    }
    public Vector3 getVelocity()
    {
        return velocity;
    }
}
