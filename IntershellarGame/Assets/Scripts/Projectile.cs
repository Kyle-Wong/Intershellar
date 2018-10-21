using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    // Use this for initialization
    private Vector3 velocity;
    public float lifeTime = 4;
    private float lifeTimer = 0;
    public GameObject hurtParticle;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if(lifeTimer > lifeTime)
        {
            Destroy(gameObject);
        }
        lifeTimer += Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		//kill enemies
		if(other.gameObject.CompareTag("Enemy"))
        {
			other.GetComponent<ShootingEnemy>().Hurt();
            GameObject particle = GameObject.Instantiate(hurtParticle, transform.position,Quaternion.identity);
            particle.GetComponent<ParticleSystem>().Play();
        }
		if(!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Projectile"))
        {
            GetComponent<Animator>().SetTrigger("Break");
			Destroy(gameObject, 2);
        }
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
