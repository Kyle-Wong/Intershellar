using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {

    // Use this for initialization
    public string nextScene;
    [HideInInspector]
    public bool gameWon;
    [HideInInspector]
    public bool paused;
    public Canvas winCanvas;
    public Canvas deadCanvas;
    public Canvas pauseCanvas;
    private Player_Movement player;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
        gameWon = false;
        paused = false;
	}
	
	// Update is called once per frame
	void Update () {

        
        if (gameWon)
        {
            Time.timeScale = 0;
            winCanvas.enabled = true;
            if (Input.GetButtonDown("Submit"))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(nextScene);
            }
        }
        else if (player.dead())
        {
            Time.timeScale = 0;
            deadCanvas.enabled = true;
            if (Input.GetButtonDown("Submit"))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else 
        {
            if (!paused)
            {
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
                {
                    Time.timeScale = 0;
                    pauseCanvas.enabled = true;
                    paused = true;
                }
            }
            else if (paused)
            {
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
                {
                    Time.timeScale = 1;
                    pauseCanvas.enabled = false;
                    paused = false;
                }
            }
        }

	}
}
