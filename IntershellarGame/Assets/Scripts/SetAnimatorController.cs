using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorController : MonoBehaviour {
	public RuntimeAnimatorController controller;
	// Use this for initialization
	void Start () {
		GetComponent<Animator>().runtimeAnimatorController = controller;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
