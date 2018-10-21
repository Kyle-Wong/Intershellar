using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour {

    // Use this for initialization
    private Player_Movement player;
    public RectTransform exposureBar;
    public GameObject exposureBarRegion;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player.shellCount <= 0)
        {
            exposureBarRegion.SetActive(true);
            exposureBar.anchorMin = new Vector2(Mathf.Lerp(.5f,0, player.timer / player.timing), exposureBar.anchorMin.y);
            exposureBar.anchorMax = new Vector2(Mathf.Lerp(.5f,1, player.timer / player.timing), exposureBar.anchorMax.y);
        } else
        {
            exposureBarRegion.SetActive(false);
        }
	}
}
