using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitDetection : MonoBehaviour {
    public Rigidbody bulletRb;
	// Use this for initialization
	void Start () {
        bulletRb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (bulletRb.velocity.y == 0 || bulletRb.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //print("testing" + col.gameObject.tag);
        if (col.gameObject.tag == "Player") {
            PlayerHealth.playersHealth -= 10;
            Destroy(this.gameObject);
        }
        
    }
}
