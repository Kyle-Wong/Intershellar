using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public GameObject target;
	private float speed = 5;
	private int shellCount;

	[Header("follow in what range?")]
	public bool hasRange;
	public Vector2 leftLower;
	public Vector2 rightUpper;
	// Use this for initialization
	void Start () {
		shellCount = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().shellCount;
	}
	
	// Update is called once per frame
	void Update () {
		Follow();
		TestResize();
		/* 
		if(Input.GetKeyDown(KeyCode.Q))
		{
			GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().shellCount++;
			GameObject.FindGameObjectWithTag("Player").GetComponent<ShellStack>().addShell(1);
		}
		if(Input.GetKeyDown(KeyCode.R))
		{
			GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().shellCount--;
			GameObject.FindGameObjectWithTag("Player").GetComponent<ShellStack>().removeShell();
		}*/
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

	//see more things when crab gets more shell
	private void TestResize()
	{
		int crabNum = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().shellCount;
		if(crabNum >= 8 && crabNum != shellCount)
		{
			shellCount = crabNum;
			//when larger than 28 shells, only increase to 28 * 0.5 + 1
			if(shellCount > 28 && gameObject.GetComponent<Camera>().orthographicSize < 15)
				StartCoroutine(SmoothResize(15 - gameObject.GetComponent<Camera>().orthographicSize));
			else if(shellCount <= 28)
				StartCoroutine(SmoothResize(1 + 0.5f * crabNum - gameObject.GetComponent<Camera>().orthographicSize));
		}
	}

	private IEnumerator SmoothResize(float change)
	{
		for(int i = 0; i< 10; i++)
		{
			gameObject.GetComponent<Camera>().orthographicSize += (change/10);
			yield return new WaitForSeconds(0.01f);
		}
	}

}
