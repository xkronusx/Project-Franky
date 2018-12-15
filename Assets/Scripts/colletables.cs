using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colletables : MonoBehaviour {

	// Use this for initialization
    public int collectedCoins;
    public int coinHighScore;
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(30, 15, 45) * Time.deltaTime);
        collectedCoins = PlayerPrefs.GetInt("collectableCount");
        coinHighScore = PlayerPrefs.GetInt("coinHighestScore");
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.GetComponent<PlayerControls>() != null)
        {
            collectedCoins++;
            PlayerPrefs.SetInt("collectableCount", collectedCoins);
            if (collectedCoins > coinHighScore) {
                coinHighScore = collectedCoins;
                PlayerPrefs.SetInt("coinHighestScore", coinHighScore);
            }
            Destroy(this.gameObject);
        }
    }
}
