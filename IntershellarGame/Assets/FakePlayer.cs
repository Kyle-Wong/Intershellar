using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlayer : Player_Movement {

    // Use this for initialization
    public Vector2 v;
    Rigidbody2D r;
	public void Start () {
        r = GetComponent<Rigidbody2D>();
	}   
	
	// Update is called once per frame
	public void Update () {
        r.velocity = v;
	}
}
