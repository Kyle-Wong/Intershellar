using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public GameObject target;
	private float speed = 5;
	[Header("follow in what range?")]
	public bool hasRange;
	public Vector2 leftLower;
	public Vector2 rightUpper;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Follow();
	}

	private void Follow()
	{
		Vector2 distance = target.transform.position - transform.position;
		if(!hasRange)
		{
			transform.position += new Vector3(distance.x, distance.y, 0);
		}
		else
		{ 
			//move at x direction
			if(transform.position.x <= rightUpper.x && transform.position.x >= leftLower.x)
			{
				transform.position += new Vector3(distance.x, 0, 0);
			}
			//move at y direction
			if(transform.position.y <= rightUpper.y && transform.position.y >= leftLower.y)
			{
				transform.position += new Vector3(0, distance.y, 0);
			}	
		}	
	}

}
