using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserPowerUpTimer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(laserTimer());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator laserTimer()
    {
        //print("before");
        //print(Time.time);
        yield return new WaitForSeconds(30);
        this.GetComponent<PlayerControls>().laserPoweredUp = false;
        this.GetComponent<Renderer>().material = this.GetComponent<PlayerControls>().playerMainMat;
        print(Time.time);
        //print("after");
        this.enabled = false;
    }
}
