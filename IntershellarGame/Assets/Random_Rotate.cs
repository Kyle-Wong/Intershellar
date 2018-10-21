using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Rotate : MonoBehaviour {
    public float rotate_speed;
    private float sign = 1.0f;
    private float flip;
    private float randomRotation;
	// Use this for initialization
	void Start () {
        flip = Random.Range(0.0f, 0.1f);
        if (flip <= 0.05f)
        {
            sign = -1.0f;
        }
        randomRotation = Random.Range(0.0f,0.5f) * 10.0f;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0,0,randomRotation * sign);
	}
}
