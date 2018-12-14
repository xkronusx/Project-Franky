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
    public bool tpPoweredUp = false;
    public int tpCharges = 0;
    public bool laserPoweredUp = false;
    public GameObject laserShot;
    public GameObject currShot;
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
        if (Input.GetKey(KeyCode.LeftControl) && running == false)
        {
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
            jumps++;
        }
        if (Input.GetButtonDown("Fire1") && tpPoweredUp == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.Log("Mouse position on mouse button press: " + Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //print("point one: " + hit.point.x + " point two: " + hit.point.y);
                if (hit.point.y > 0)
                {
                    rb.velocity = Vector3.zero;
                    this.transform.position = new Vector3(hit.point.x, hit.point.y, 0);
                    GetComponent<DamageCheck>().canBeDamaged = false;
                    Camera.main.GetComponent<PlayerInv>().playerIsSafe = true;
                    tpCharges--;
                    if (tpCharges == 0) {
                        tpPoweredUp = false;
                    }
                    StartCoroutine(invFrames());
                }
            }
        }
        if (Input.GetButtonDown("Fire1") && laserPoweredUp == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Vector3 test = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,0));
            //print(test);
            //Debug.Log("Mouse position on mouse button press: " + Input.mousePosition);
            RaycastHit shotHit;
            if (Physics.Raycast(ray, out shotHit))
            {
                //print("point one: " + hit.point.x + " point two: " + hit.point.y);
                /*
                currShot = Instantiate(laserShot, this.transform.position, Quaternion.identity);
                Vector3 shotTarget = new Vector3(hit.transform.position.x - this.transform.position.x, hit.transform.position.y - this.transform.position.y,0).normalized;
                currShot.GetComponent<Rigidbody>().velocity = shotTarget;
                print(shotTarget);
                Debug.DrawLine(this.transform.position, this.transform.position + shotTarget * 10, Color.red, Mathf.Infinity);
                //currShot.transform.position = Vector3.Lerp(currShot.transform.position,hit.transform.position,5 * Time.deltaTime);
                print(this.transform.position);
                print(hit.transform.position);
                */
                /*
                Vector3 pos = Camera.main.transform.position;
                Vector3 dir = (this.transform.position - Camera.main.transform.position).normalized;
                Debug.DrawLine(pos, pos + dir * 10, Color.red, Mathf.Infinity);
                */
                //print(Input.mousePosition);
                //print(this.gameObject);
                //print(this.gameObject.transform.position);
                //print(shotHit.transform.position);
                //print(shotHit.point.x);
                //print(shotHit.point.y);
                currShot = Instantiate(laserShot, this.transform.position, Quaternion.identity);
                Vector3 myPos = this.transform.position;
                Vector3 shotDirection = new Vector3(shotHit.point.x - this.gameObject.transform.position.x, shotHit.point.y - this.gameObject.transform.position.y, 0).normalized;
                //Vector3 dir = new Vector3(test.x - this.gameObject.transform.position.x, test.y - this.gameObject.transform.position.y, 0).normalized;
                Debug.DrawLine(myPos, myPos + shotDirection * 100, Color.red, Mathf.Infinity);
                print(shotDirection);
                currShot.GetComponent<Rigidbody>().velocity = shotDirection * 10;
                currShot.transform.rotation = Quaternion.LookRotation(currShot.GetComponent<Rigidbody>().velocity);
                if (shotDirection.x > 0)
                {
                    currShot.transform.rotation = Quaternion.Euler(0, 0, -1 * (currShot.transform.eulerAngles.x - currShot.transform.eulerAngles.y));
                }
                if (shotDirection.x < 0)
                {
                    currShot.transform.rotation = Quaternion.Euler(0, 0, (currShot.transform.eulerAngles.x - currShot.transform.eulerAngles.y));
                }
            }
        }
    }
    /*
    public void SpawnBullets()
    {

        if (Physics.Linecast(transform.position, target.position))
        {
            //Debug.Log("blocked");
            Debug.DrawRay(transform.position, target.position, Color.blue);
            GameObject bBalls = Instantiate(bulletBalls[0], this.transform.position, Quaternion.identity);
            //print(target.position.x);
            //print(target.position.y);
            Vector3 playerPos = new Vector3(target.position.x, target.position.y, target.position.z).normalized;
            if (target.position.x < this.transform.position.x && target.position.x > 0)
            {
                bBalls.GetComponent<Rigidbody>().AddForce(-playerPos.x * 600, playerPos.y * 800, 0);
            }
            else
            {
                bBalls.GetComponent<Rigidbody>().AddForce(playerPos.x * 600, playerPos.y * 800, 0);
            }

            //print(playerPos);
        }

    }
    */

    IEnumerator invFrames()
    {
        //print("before");
        yield return new WaitForSeconds(2);
        GetComponent<DamageCheck>().canBeDamaged = true;
        Camera.main.GetComponent<PlayerInv>().playerIsSafe = false;
        //print("after");

    }
    void OnCollisionEnter(Collision col)
    {
        //print("this" + this.gameObject);
        //print(col.gameObject);
        //if (col.gameObject.transform.position.y < this.transform.position.y && col.gameObject.tag == "Enemy") {
        if (rb.transform.position.y > col.transform.position.y && col.gameObject.tag == "Enemy" && col.gameObject.GetComponent<EnemyCleanup>().canBeHurt == true)
        {
            print("DAMAGE ENEMY");
            col.gameObject.GetComponent<EnemyCleanup>().enemyHealth -= 10;
            rb.AddExplosionForce(500f,this.transform.position,500f);
            //this.GetComponent<Rigidbody>().AddExplosionForce(500f, hit.collider.gameObject.GetComponent<Rigidbody>().transform.position, 500f);
        }
        if (rb.transform.position.y > col.transform.position.y && col.gameObject.tag == "Enemy" && col.gameObject.GetComponent<EnemyCleanup>().canBeHurt == false)
        {
            print("ENEMY CANT BE DAMAGED");
            rb.AddExplosionForce(500f, this.transform.position, 500f);
        }
    }

}
