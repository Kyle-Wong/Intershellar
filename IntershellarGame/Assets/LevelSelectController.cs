using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSelectController : MonoBehaviour {

    // Use this for initialization
    public string[] levelNames;
    public Color activeColor;
    public Color inactiveColor;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            goToMainMenu();
        }
	}
    public void startLevel(int x)
    {
        SceneManager.LoadScene(levelNames[x]);
    }
    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void makeActive(Image i)
    {
        i.color = activeColor;
    }
    public void makeInactive(Image i)
    {
        i.color = inactiveColor;
    }
}
