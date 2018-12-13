﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void mainMenuLoad()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LevelOneLoad()
    {
        SceneManager.LoadScene("LevelOne");
    }
    public void LevelTwoLoad()
    {
        SceneManager.LoadScene("LevelTwo");
    }
    public void LevelThreeLoad()
    {
        SceneManager.LoadScene("LevelThree");
    }
    /*
    public void highScorePageLoad()
    {
        SceneManager.LoadScene("HighScores");
    }
    */
}
