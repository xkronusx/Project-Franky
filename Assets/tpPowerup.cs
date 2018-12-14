using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpPowerup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(30, 15, 45) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.GetComponent<PlayerControls>() != null)
        {
            if (col.GetComponent<PlayerControls>().tpPoweredUp != true) {
                col.GetComponent<PlayerControls>().tpPoweredUp = true;
                col.GetComponent<PlayerControls>().tpCharges = 5;
            }
            Destroy(this.gameObject);
        }
    }
}

