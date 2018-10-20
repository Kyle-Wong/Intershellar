using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Rotate : MonoBehaviour {
    public float rotate_speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0,0,rotate_speed);
	}
}
