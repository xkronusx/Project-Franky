using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    // Use this for initialization
    public Rigidbody groundRb;
	void Start () {
        groundRb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision col)
    {
        //print(col);
        if (col.gameObject.GetComponent<PlayerControls>() != null)
        {
            PlayerControls pC = col.gameObject.GetComponent<PlayerControls>();
            pC.jumps = 0;
            /*
            if (mS.IsSafe == true)
            {
                print("safety!");
            }
            if (mS.IsSafe == false)
            {
                print("dead!");
                mS.spherePlayer.transform.position = restartPos;
                mS.spherePlayer.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            */
        }
    }
}
