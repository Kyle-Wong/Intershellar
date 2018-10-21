using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {

	// Use this for initialization
   
	void Start () {
        if (GameObject.FindGameObjectsWithTag("UniqueMusicObject").Length > 1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
