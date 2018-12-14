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
    void Update() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.blue);
            //Debug.Log("Did Hit floor");
            //print(hit.collider.gameObject.tag);

            if (hit.collider.gameObject.tag == "Ground" || hit.collider.gameObject.tag == "Enemy")
            {

                //print(hit.collider.gameObject.tag);
                //print(hit.collider.gameObject.name + "woot");
                if (this.gameObject.GetComponent<PlayerControls>() != null)
                {
                    PlayerControls pC = this.gameObject.GetComponent<PlayerControls>();
                    pC.jumps = 0;
                }

            }
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (col.gameObject.GetComponent<PlayerControls>() != null)
            {
                /*
                PlayerControls pC = col.gameObject.GetComponent<PlayerControls>();
                pC.jumps = 0;
                */

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
}
