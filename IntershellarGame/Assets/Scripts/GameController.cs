using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
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
    private EventSystem eventSystem;
    public GameObject resumeButton;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
        player.transform.Find("Crab_sprite").GetComponent<Animator>().enabled = false;
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
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
            StartCoroutine(PlayerDie());
        }
        else 
        {
            if (!paused)
            {
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
                {
                    player.setInput(false);
                    Time.timeScale = 0;
                    pauseCanvas.enabled = true;
                    paused = true;
                    eventSystem.SetSelectedGameObject(resumeButton);
                }
            }
            else if (paused)
            {
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
                {
                    player.setInput(true);
                    Time.timeScale = 1;
                    pauseCanvas.enabled = false;
                    paused = false;
                }
            }
        }

	}

    private IEnumerator PlayerDie()
    {
        player.transform.Find("Crab_sprite").GetComponent<Animator>().enabled = true;
        player.transform.Find("Crab_sprite").GetComponent<Animator>().SetTrigger("Die");
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
        deadCanvas.enabled = true;
        yield return new WaitUntil(() => Input.GetButtonDown("Submit"));
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    public void resume()
    {
        if (paused)
        {
            player.setInput(true);
            Time.timeScale = 1;
            pauseCanvas.enabled = false;
            paused = false;
        }
    }
    public void goToMainMenu()
    {
        if (paused)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }
    }

}
