using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {
    private Player_Movement shellnum;
    public float timer;
    //private bool timing = false;
	// Use this for initialization
	void Start () {
        shellnum = GetComponent<Player_Movement>();
	}
	
	// Update is called once per frame
	void Update () {
        NoShells();
	}
    void NoShells()
    {
        Debug.Log(timer);
        if (shellnum.shellCount == 0)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
