using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {

    // Use this for initialization
    public string nextScene;
    public AudioClip dieSE;
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
        player.transform.Find("Crab_sprite").GetComponent<Animator>().enabled = false;
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

    private IEnumerator PlayerDie()
    {
        AudioSource.PlayClipAtPoint(dieSE, GameObject.FindWithTag("MainCamera").transform.position);
        player.transform.Find("Crab_sprite").GetComponent<Animator>().enabled = true;
        player.transform.Find("Crab_sprite").GetComponent<Animator>().SetTrigger("Die");
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
        deadCanvas.enabled = true;
        yield return new WaitUntil(() => Input.GetButtonDown("Submit"));
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

}
