using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellList : MonoBehaviour {

    // Use this for initialization
    public Sprite[] shellSprite;
    public Sprite[] playerShellSprite;
    public Sprite[] tripleShellSprite;
    public RuntimeAnimatorController[] shellAnimation;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public Sprite getShellSprite(int x)
    {
        return shellSprite[x];
    }
    public Sprite getPlayerShellSprite(int x)
    {
        return playerShellSprite[x];
    }
    public Sprite getTripleShellSprite(int x)
    {
        return tripleShellSprite[x];
    }
    public RuntimeAnimatorController getAnimation(int x)
    {
        return shellAnimation[x];
    }
}
