using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

    // Use this for initialization
    public Transform mainCam;
    public Player_Movement playerMovement;
    float screenWidth;
    float screenHeight;
    public float parallaxScale;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > mainCam.position.x+screenWidth/2)
            transform.position += Vector3.left * screenWidth;
        if (transform.position.x < mainCam.position.x - screenWidth/2)
            transform.position += Vector3.right * screenWidth;
        if (transform.position.y > mainCam.position.y+screenHeight / 2)
            transform.position += Vector3.down * screenHeight;
        if (transform.position.y < mainCam.position.y- screenHeight/2)
            transform.position += Vector3.up * screenHeight;

        transform.position += -1 * (Vector3)playerMovement.gameObject.GetComponent<Rigidbody2D>().velocity * parallaxScale*Time.deltaTime;


	}
    public void setBounds(float width, float height)
    {
        screenWidth = width;
        screenHeight = height;
    }
}
