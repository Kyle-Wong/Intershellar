using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour {

    // Use this for initialization
    public Transform bigStarPrefab;
    public Transform midStarPrefab;
    public Transform smallStarPrefab;
    public int bigStarCount;
    public int midStarCount;
    public int smallStarCount;
    private float screenWidth;
    private float screenHeight;
    private Camera mainCamera;
    private GameObject player;
    public bool requirePlayer = true;
	void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
        screenWidth = mainCamera.ViewportToWorldPoint(new Vector2(1, 0)).x - mainCamera.ScreenToWorldPoint(new Vector2(0, 0)).x;
        screenHeight = mainCamera.ViewportToWorldPoint(new Vector2(0, 1)).y - mainCamera.ScreenToWorldPoint(new Vector2(0, 0)).y;
        screenHeight *= 3.1f;   //let stars go a bit out of the edge of the screen
        screenWidth *= 3.1f;
        generateStars(bigStarPrefab, bigStarCount);
        generateStars(midStarPrefab, midStarCount);
        generateStars(smallStarPrefab, smallStarCount);
    }

    // Update is called once per frame
    void Update () {
	}
    private void generateStars(Transform starPrefab,int numStars)
    {

        Vector3 rngTrans = new Vector3();
        if (requirePlayer)
        {
            for (int i = 0; i < numStars; i++)
            {
                rngTrans = transform.position + Vector3.right * (Random.Range(-screenWidth / 2, screenWidth / 2)) + Vector3.up * (Random.Range(-screenHeight / 2, screenHeight / 2));
                Transform newStar = Instantiate(starPrefab, rngTrans, Quaternion.identity);
                newStar.parent = transform;
                newStar.GetComponent<Star>().mainCam = mainCamera.transform;
                newStar.GetComponent<Star>().playerMovement = player.GetComponent<Player_Movement>();
                newStar.GetComponent<Star>().setBounds(screenWidth, screenHeight);
            }
        } else
        {
            for (int i = 0; i < numStars; i++)
            {
                rngTrans = transform.position + Vector3.right * (Random.Range(-screenWidth / 2, screenWidth / 2)) + Vector3.up * (Random.Range(-screenHeight / 2, screenHeight / 2));
                Transform newStar = Instantiate(starPrefab, rngTrans, Quaternion.identity);
                newStar.parent = transform;
                newStar.GetComponent<Star>().mainCam = mainCamera.transform;
                newStar.GetComponent<Star>().playerMovement = player.GetComponent<Player_Movement>();
                newStar.GetComponent<Star>().setBounds(screenWidth, screenHeight);
            }
        }
    }
}
