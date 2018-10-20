using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShellShot : MonoBehaviour {
	public GameObject shell;//we need to throw sth
	public int initialRotation;
	public float projectForce;	
	public float dashForce;	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//shoot a shell at opposite direction and dash
	private void ShootShell()
	{
		//project shell
		GameObject shellObject = GameObject.Instantiate(shell, transform.position, Quaternion.identity);
	} 

}
