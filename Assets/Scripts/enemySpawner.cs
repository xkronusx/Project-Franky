using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {
    public GameObject[] enemies;
    public int enemyChoice;
	// Use this for initialization
	void Start () {
        enemyChoice = Random.Range(0, enemies.Length);
        Instantiate(enemies[enemyChoice], this.transform.position + (transform.up * 5), transform.rotation);
        enemyChoice = Random.Range(0, enemies.Length);
        Instantiate(enemies[enemyChoice], this.transform.position + (transform.right * 2), transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
