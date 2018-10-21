using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
	public float speed;
	public GameObject hurtParticle;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SetVelocity(float z)
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(z * Mathf.Deg2Rad), Mathf.Sin(z * Mathf.Deg2Rad)) * speed;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//when hit player
		if(other.CompareTag("Player"))
		{
			GameObject particle = GameObject.Instantiate(hurtParticle, transform.position,Quaternion.identity);
			particle.GetComponent<ParticleSystem>().Play();
			other.GetComponent<Player_Movement>().Lose_Shell();
			Destroy(gameObject);
		}
	}

}
