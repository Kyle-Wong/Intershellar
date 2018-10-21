﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MainMenuController : MonoBehaviour {

    // Use this for initialization
    public string firstLevelName;
    public string creditsSceneName;
    public string levelSelectName;
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void goToLevelSelect()
    {
        SceneManager.LoadScene(levelSelectName);
    }
    public void startGame()
    {
        SceneManager.LoadScene(firstLevelName);
    }
    public void goToCredits()
    {
        SceneManager.LoadScene(creditsSceneName);
    }
    public void quitGame()
    {
        Application.Quit();
    }
   
}
