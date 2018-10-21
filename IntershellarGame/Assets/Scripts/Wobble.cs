using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour {

    // Use this for initialization
    public float xDist;
    public float yDist;
    public float xTimeScale;
    public float yTimeScale;
    private Vector3 originalPosition;
	void Start () {
        originalPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = originalPosition + Vector3.right*Mathf.Cos(Time.time * xTimeScale)*xDist + Vector3.up*Mathf.Sin(Time.time * yTimeScale)*yDist;
	}
}
