using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCleanup : MonoBehaviour {
    public Rigidbody enemyRb;
    public int enemyHealth;
    public bool canBeHurt = true;
	// Use this for initialization
	void Start () {
        enemyRb = GetComponent<Rigidbody>();
        if(this.gameObject.tag == "Enemy")
        {
            enemyHealth = 20;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(enemyRb.transform.position.y < -20)
        {
            Destroy(this.gameObject);
        }
        if (enemyHealth == 0)
        {
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