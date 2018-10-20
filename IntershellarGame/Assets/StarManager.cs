using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour {

    // Use this for initialization
    public Camera mainCamera;
    public Transform bigStarPrefab;
    public Transform midStarPrefab;
    public Transform smallStarPrefab;
    public int bigStarCount;
    public int midStarCount;
    public int smallStarCount;
    private float screenWidth;
    private float screenHeight;
    private GameObject player;
	void Start () {
        screenWidth = mainCamera.ViewportToWorldPoint(new Vector2(1, 0)).x - mainCamera.ScreenToWorldPoint(new Vector2(0, 0)).x;
        screenHeight = mainCamera.ViewportToWorldPoint(new Vector2(0, 1)).y - mainCamera.ScreenToWorldPoint(new Vector2(0, 0)).y;
        print(screenWidth + ", " + screenHeight);
        generateStars(bigStarPrefab, bigStarCount);
        generateStars(midStarPrefab, midStarCount);
        generateStars(smallStarPrefab, smallStarCount);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(mainCamera.transform.position.x,mainCamera.transform.position.y);
	}
    private void generateStars(Transform starPrefab,int numStars)
    {

        Vector3 rngTrans = new Vector3();
        for(int i = 0; i < numStars; i++)
        {
            rngTrans = transform.position + Vector3.right * (Random.Range(-screenWidth/2,screenWidth/2)) + Vector3.up * (Random.Range(-screenHeight/2,screenHeight/2));
            Transform newStar = Instantiate(starPrefab, rngTrans,Quaternion.identity);
            newStar.parent = transform;
            newStar.GetComponent<Star>().playerMovement = player.GetComponent<Player_Movement>();
            newStar.GetComponent<Star>().setBounds(screenWidth,screenHeight);
        }
    }
}
