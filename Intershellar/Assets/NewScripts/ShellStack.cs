using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellStack : MonoBehaviour {

    // Use this for initialization
    public GameObject parent;
    public float yOffset;

	void Start () {
        transform.position = parent.transform.position + parent.transform.up * parent.transform.localScale.y / 2;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = parent.transform.position + parent.transform.up * parent.transform.localScale.y / 2;
    }
}
