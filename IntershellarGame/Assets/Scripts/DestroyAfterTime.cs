using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {
	public float time;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, time);
    }
}
