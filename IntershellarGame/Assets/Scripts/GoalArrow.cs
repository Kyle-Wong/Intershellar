using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalArrow : MonoBehaviour {
	public float distanceFromPlayer;
	public float rotationAmend;
	// Use this for initialization
	private GameObject player;
	private GameObject goal;
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		goal = GameObject.FindGameObjectWithTag("Goal");
	}
	
	// Update is called once per frame
	void Update () {
		//set the rotation
		Vector2 differ = goal.transform.position - player.transform.position;
		float radian = Mathf.Atan2(differ.y, differ.x);
		transform.eulerAngles = new Vector3(0, 0, radian * Mathf.Rad2Deg + rotationAmend);
		//set the position
		transform.position = player.transform.position + new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0) * distanceFromPlayer;
	}
}
