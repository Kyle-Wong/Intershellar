using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShellShot : MonoBehaviour {
	public GameObject shell;//we need to throw sth
	public int initialRotation;
	public float projectForce;	
	public float dashForce;	
	//
	public ParticleSystem particle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Vertical"))
			ShootShell();
	}
	
	//shoot a shell at opposite direction and dash
	private void ShootShell()
	{
		//if has shell...

		//calculate the direction of the player
		Vector2 playerDir = new Vector2(Mathf.Cos(Mathf.Deg2Rad * (transform.eulerAngles.z + initialRotation)),
										Mathf.Sin(Mathf.Deg2Rad * (transform.eulerAngles.z + initialRotation)));
		//project shell
		GameObject shellObject = GameObject.Instantiate(shell, transform.position, Quaternion.identity);
		shellObject.GetComponent<Rigidbody2D>().AddForce(-playerDir * projectForce,ForceMode2D.Impulse);
		//dash self
		GetComponent<Rigidbody2D>().AddForce(playerDir * dashForce, ForceMode2D.Impulse);

		//shoot particle
		particle.Play();
	} 

}
