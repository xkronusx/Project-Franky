using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DamageCheck : MonoBehaviour {

    
    CharacterController controller;
    public bool canBeDamaged = true;
    void Start()
    {

    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit floor");
            
            if (hit.collider.gameObject.tag == "Enemy")
            {
                //print(hit.collider.gameObject.tag);
                //print(hit.collider.gameObject.name + "woot");

            }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 0.6f) || Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 0.6f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit right");
            if (hit.collider.gameObject.tag == "Enemy" && canBeDamaged ==  true)
            {
                //print(hit.collider.gameObject.name + "oof");
                PlayerHealth.playersHealth -= 10;
                this.GetComponent<Rigidbody>().AddExplosionForce(500f, hit.collider.gameObject.GetComponent<Rigidbody>().transform.position, 500f);
                //hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(0, 20f, 0, ForceMode.Impulse);
                //AddExplosionForce(1000f,this.transform.position, 100f);
                //print("this is" + hit.collider.gameObject.GetComponent<Rigidbody>());
                //rb.AddForce((-1 * move), 0, 0, ForceMode.Impulse);
                canBeDamaged = false;
                StartCoroutine(invFrames());
                

            }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 0.6f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.blue);
            //Debug.Log("Did Hit left");
            if (hit.collider.gameObject.tag == "Enemy")
            {
                //print(hit.collider.gameObject.name + "woot");
            }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(1, -1f, 0), out hit, 0.75f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(1, -1f, 0) * hit.distance, Color.blue);
            //Debug.Log("Did Hit leftup");
            //print(hit.collider.gameObject);
            if (hit.collider.gameObject.name == "LeftWall")
            {
                //print(hit.collider.gameObject.name + "woot");
            }
        }
    }
    IEnumerator invFrames()
    {
        //print("before");
        yield return new WaitForSeconds(1);
        canBeDamaged = true;
        //print("after");
        
    }
}
