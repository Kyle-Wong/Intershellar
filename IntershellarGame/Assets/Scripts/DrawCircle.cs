using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircle : MonoBehaviour {

    // Use this for initialization
    public int numPoints;
    private float stepSize;
    public float radius;
    private LineRenderer lineRenderer;
    private Vector3[] points;
	void Awake () {
        points = new Vector3[numPoints];
        lineRenderer = GetComponent<LineRenderer>();
        stepSize = Mathf.PI*2 / numPoints;
        lineRenderer.positionCount = numPoints;
	}
	
	// Update is called once per frame
	void Update () {
        for(int i = 0; i < points.Length; i++)
        {
            points[i] = transform.position + new Vector3(Mathf.Cos(stepSize * i), Mathf.Sin(stepSize * i)) * radius;
        }
        lineRenderer.SetPositions(points);
	}
    public void initializeCircle(int numP, float r)
    {
        numPoints = numP;
        radius = r;
        points = new Vector3[numPoints];
        lineRenderer = GetComponent<LineRenderer>();
        stepSize = Mathf.PI * 2 / numPoints;
        lineRenderer.positionCount = numPoints;
    }
    public void setRadius(float r)
    {
        radius = r;
    }
    public void setColor(Color c)
    {
        lineRenderer.startColor = c;
        lineRenderer.endColor = c;
    }
}
