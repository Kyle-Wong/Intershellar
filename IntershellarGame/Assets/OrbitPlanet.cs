using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPlanet : MonoBehaviour {

    // Use this for initialization
    public GameObject planet;
    private float distance;
    public float angularSpeed;
    private float angle;
	void Start () {
		distance = (planet.transform.position - transform.position).magnitude;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = planet.transform.position + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * distance;
        angle += angularSpeed * Time.deltaTime;
	}
    public void setPlanet(GameObject p)
    {
        planet = p;
        distance = (planet.transform.position - transform.position).magnitude;

    }
}
