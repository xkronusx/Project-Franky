using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public Rigidbody rb;
    public float move = 0.5f;
    public float jump = 10f;
    public float jumps = 0;
    public bool running = false;
    public float testvalue = 1f;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        /*
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 1f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit right");
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 0.6f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.blue);
            //Debug.Log("Did Hit left");
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(-1,1f,0), out hit, testvalue))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-1, 1f, 0) * hit.distance, Color.blue);
            Debug.Log("Did Hit leftup");
            print(hit.collider.gameObject);
            if (hit.collider.gameObject.name == "LeftWall") {
                print(hit.collider.gameObject.name + "woot");
                    }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.white);
            //Debug.Log("Did not Hit");
        }
        //Debug.DrawRay(transform.position, transform.TransformDirection(-1, 1f, 0), Color.blue);
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) , Color.blue);
        //Debug.DrawRay(transform.position, transform.TransformDirection(-1, -1f, 0), Color.blue);

        Debug.DrawRay(transform.position, transform.TransformDirection(1, 1f, 0), Color.blue);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right), Color.blue);
        Debug.DrawRay(transform.position, transform.TransformDirection(1, -1f, 0), Color.blue);

        /*
        Debug.DrawRay(transform.position, -transform.up * 4.0f, Color.green); // This is the forward direction

        float rad = 45.0f * Mathf.Deg2Rad;    // 45° from forward
        Vector3 minDirection = new Vector3(Mathf.Sin(rad), -Mathf.Cos(rad), 0);   // At 0° it's Vector3(0,0,1) or Vector3.forward
        Debug.DrawRay(transform.position, minDirection * 5.0f, Color.red);

        float brad = 315.0f * Mathf.Deg2Rad;    // -45° from forward
        Vector3 maxDirection = new Vector3(Mathf.Sin(brad), -Mathf.Cos(brad), 0);
        Debug.DrawRay(transform.position, maxDirection * 5.0f, Color.red);
        */
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce((-1 * move), 0, 0, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(move, 0, 0, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0, move, 0, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(0, (-1 * move), 0, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftControl) && running == false) {
            move *= 2;
            running = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            move /= 2;
            running = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumps < 2)
        {
            rb.AddForce(0, jump, 0, ForceMode.Impulse);
            ++jumps;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        //print("this" + this.gameObject);
        //print(col.gameObject);
        //if (col.gameObject.transform.position.y < this.transform.position.y && col.gameObject.tag == "Enemy") {
        if (rb.transform.position.y < this.transform.position.y && col.gameObject.tag == "Enemy")
        {
            print("DAMAGE ENEMY");
        }
    }

}
