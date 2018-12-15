using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winScript : MonoBehaviour {

    public GameObject winGameCanvas;
    // Use this for initialization
    void Start () {
        winGameCanvas = Camera.main.GetComponent<PauseMenu>().PauseCanvas;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        winGameCanvas.gameObject.SetActive(true);
        print("test");
        Camera.main.GetComponent<PauseMenu>().gameOverText.text = "You have won!";
    }
}
