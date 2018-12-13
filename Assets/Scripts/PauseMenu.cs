using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseCanvas;
    private bool paused = false;
	// Use this for initialization
	void Start ()
    {
		PauseCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (paused == true)
            {
                Time.timeScale = 1.0f;
                PauseCanvas.gameObject.SetActive(false);
                //Screen.showCursor = false;
                //Screen.lockCursor = true;
                //Camera.audio.Play();
                paused = false;
            }
            else
            {
                Time.timeScale = 0.0f;
                PauseCanvas.gameObject.SetActive(true);
                //Screen.showCursor = true;
                //Screen.lockCursor = false;
                //Camera.audio.Pause();
                paused = true;
            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        PauseCanvas.gameObject.SetActive(false);
        //Screen.showCursor = false;
        //Screen.lockCursor = true;
        //Camera.audio.Play();
    }
} 

