using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitRing : MonoBehaviour {

    // Use this for initialization
    private Planet planet;
    private float minRange;
    private float maxRange;
    public Color farColor;
    public Color closeColor;
    private DrawCircle drawer;
    private Transform player;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        planet = GetComponent<Planet>();
        minRange = planet.circleAroundRadius;
        maxRange = planet.rangeRadius;
        drawer = GetComponent<DrawCircle>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector2.Distance(transform.position,player.position) < maxRange)
        {
            float distance = (transform.position - player.position).magnitude;
            drawer.setRadius(distance);
            Color c = Color.Lerp(closeColor, farColor, (distance-minRange) / (maxRange-minRange));  //don't set maxrange == minrange fools
            drawer.setColor(c);
        }

	}
}
