using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mmCollectables : MonoBehaviour {

    public Text collectableShow;
    public int collection;
    // Use this for initialization
    void Start () {
        collection = PlayerPrefs.GetInt("collectableCount");
        collectableShow.text = "Collectables: " + collection;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
