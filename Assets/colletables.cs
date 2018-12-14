using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colletables : MonoBehaviour {

	// Use this for initialization
    public int collectedCoins;
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(30, 15, 45) * Time.deltaTime);
        collectedCoins = PlayerPrefs.GetInt("collectableCount");
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.GetComponent<PlayerControls>() != null)
        {
            collectedCoins++;
            PlayerPrefs.SetInt("collectableCount", collectedCoins);
            Destroy(this.gameObject);
        }
    }
}
