using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

    // Use this for initialization
    public Player_Movement playerMovement;
    float screenWidth;
    float screenHeight;
    public float parallaxScale;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localPosition.x > screenWidth/2)
            transform.position += Vector3.left * screenWidth;
        if (transform.localPosition.x < -screenWidth/2)
            transform.position += Vector3.right * screenWidth;
        if (transform.localPosition.y > screenHeight/2)
            transform.position += Vector3.down * screenHeight;
        if (transform.localPosition.y < -screenHeight/2)
            transform.position += Vector3.up * screenHeight;

        //transform.position += -1 * playerMovement.transform.forward * playerMovement.getVelocity() * parallaxScale;


	}
    public void setBounds(float width, float height)
    {
        screenWidth = width;
        screenHeight = height;
    }
}
