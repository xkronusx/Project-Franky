using System.Collections;
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
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
    public void LevelOneLoad()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("LevelOne");
    }
    public void LevelTwoLoad()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("LevelTwo");
    }
    public void LevelThreeLoad()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("LevelThree");
    }
    /*
    public void highScorePageLoad()
    {
        SceneManager.LoadScene("HighScores");
    }
    */
}
