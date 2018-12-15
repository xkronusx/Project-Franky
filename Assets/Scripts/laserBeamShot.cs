using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserBeamShot : MonoBehaviour {

    // Use this for initialization
    public float cullShot = 5f;
	void Start () {
        Destroy(this.gameObject, cullShot);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyCleanup>().enemyHealth = 0;
        }
    }
}