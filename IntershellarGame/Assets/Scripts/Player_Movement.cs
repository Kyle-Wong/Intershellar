using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    Vector3 velocity;
    float crab_speed = 1f;
    float rotation_speed = 10f;

	// Use this for initialization
	void Start () {
        velocity.Set(0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        float rotating = Input.GetAxis("Rotation") * rotation_speed;
        if (Input.GetButton("Rotation"))
        {
            transform.Rotate(0, 0, rotating);
        }
        /*if (Input.GetButtonDown("Push"))
        {
            transform.Translate
        }*/
	}
    //Activates when crab collides with detached shell. Places shell on top of stack.
    public void Gain_Shell(int worth)
    {

    }

    public float getVelocity()
    {
        ;
    }
}
