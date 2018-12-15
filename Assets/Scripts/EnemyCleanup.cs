using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCleanup : MonoBehaviour {
    public Rigidbody enemyRb;
    public int enemyHealth;
    public bool canBeHurt = true;
    public GameObject coinsFab;
    public GameObject[] powerUps;
    public int dropRate = 0;
    public int dropType;
    public int enemyDeadNum;
    // Use this for initialization
    void Start () {
        enemyRb = GetComponent<Rigidbody>();
        if(this.gameObject.tag == "Enemy")
        {
            enemyHealth = 20;
        }
        if (this.gameObject.name == "BossSphere")
        {
            enemyHealth += 100;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(enemyRb.transform.position.y < -20)
        {
            Destroy(this.gameObject);
        }
        if (enemyHealth == 0 || enemyHealth < 0)
        {
            enemyDeadNum = PlayerPrefs.GetInt("enemiesDestroyed");
            enemyDeadNum++;
            PlayerPrefs.SetInt("enemiesDestroyed", enemyDeadNum);

            Instantiate(coinsFab, this.transform.position, transform.rotation);
            if (this.gameObject.name != "BossSphere")
            {
                dropRate = Random.Range(0, 40);
                dropType = Random.Range(0, powerUps.Length);
            }
            if (dropRate > 30) {
                Instantiate(powerUps[dropType], this.transform.position + (transform.up  * 4), transform.rotation);
            }
            if (this.gameObject.name == "BossSphere(Clone)")
            {
                Camera.main.GetComponent<levelGeneration>().bossDefeated = true;
                print("DEFEATED BOSS");
                GameObject.FindGameObjectWithTag("Player").GetComponent<FollowPlayer>().bossFight = false;
            }

            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "LeftWall")
        {
            Destroy(this.gameObject);
        }
    }
}