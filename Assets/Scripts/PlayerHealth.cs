using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public static int playersHealth = 100;
    public float x = 1;
    public float y = 1;
    public int currentCoins;
    public Text showHealth;
    public Text collectableShow;
    void Start()
    {
        
    }
    void Update()
    {
        //print(playersHealth);
        /*
        Quaternion randomRot = Quaternion.Euler(Random.Range(-40f, 40f),Random.Range(-50f, 0f),Random.Range(-40f, 40f));

        Vector3 coneVector = randomRot * -transform.up;

        Debug.DrawRay(transform.position, transform.forward * 3f, Color.yellow, 0.05f);
        Debug.DrawRay(transform.position, coneVector * 3f, Color.red, 3f);
        */
        currentCoins = PlayerPrefs.GetInt("collectableCount");
        collectableShow.text = "Coins: " + currentCoins;
        Debug.DrawRay(transform.position, transform.TransformDirection(x, y, 0), Color.blue);
        showHealth.text = "Health: " + playersHealth;
    }
}
