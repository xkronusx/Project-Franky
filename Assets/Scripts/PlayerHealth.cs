using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public static int playersHealth = 100;
    public float x = 1;
    public float y = 1;
    public GameObject gameOverCanvas;
    public int currentCoins;
    public int currentHighCoins;
    public int currentEnemyCount;
    public Text showHealth;
    public Text collectableShow;
    public Text collectableHighShow;
    public Text currentPowerUpStatus;
    public Text defeatedNumOfEnemies;
    void Awake()
    {
        PlayerPrefs.SetInt("enemiesDestroyed", 0);
    }
    void Start()
    {
        playersHealth = 100;
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
        currentHighCoins = PlayerPrefs.GetInt("coinHighestScore");
        collectableHighShow.text = "Coins Highscore: " + currentHighCoins;
        currentEnemyCount = PlayerPrefs.GetInt("enemiesDestroyed");
        defeatedNumOfEnemies.text = "Enemies Defeated: " + currentEnemyCount;
        //Debug.DrawRay(transform.position, transform.TransformDirection(x, y, 0), Color.blue);
        showHealth.text = "Health: " + playersHealth;
        if (playersHealth < 0)
        {
            if (Time.timeScale == 1.0f) {
                Time.timeScale = 0.0f;
            }
            gameOverCanvas.gameObject.SetActive(true);
            Camera.main.GetComponent<PauseMenu>().gameOverText.text = "You have died!";
}
    }
}
