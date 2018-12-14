using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public Transform target;
    public Rigidbody teleporterRb;
    public Collider[] colliders;
    public bool canDamagePlayer = true;
    public Material mainMat;
    public Material transMat;

    // Use this for initialization
    void Start()
    {
        teleporterRb = GetComponent<Rigidbody>();
        mainMat = GetComponent<Renderer>().material;
        InvokeRepeating("Teleporting", 2f, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Teleporting()
    {

        if (Physics.Linecast(transform.position, target.position))
        {
            //Debug.Log("blocked");
            Debug.DrawRay(transform.position, target.position, Color.blue);
            //print(target.position);
            teleporterRb.velocity = Vector3.zero;
            transform.position = new Vector3(target.position.x + 2f, target.position.y, target.position.z);
            Invoke("Explosion", 1f);
            //teleporterRb.AddExplosionForce(10, new Vector3(this.transform.position.x + -1.5f, this.transform.position.y, this.transform.position.z), 100, 0 ,ForceMode.Impulse);
            //this.GetComponent<Rigidbody>().AddExplosionForce(500f, hit.collider.gameObject.GetComponent<Rigidbody>().transform.position, 500f);
        }
    }
    public void Explosion()
    {
        PlayerInv pI = Camera.main.GetComponent<PlayerInv>();
        colliders = Physics.OverlapSphere(this.transform.position, 10);
        foreach (Collider col in colliders) {
            //if (col.GetComponent<Rigidbody>() == null) continue;
            if (col.gameObject.tag != "Enemy" || col.gameObject.name != "Backwall") {
                col.GetComponent<Rigidbody>().AddExplosionForce(10, this.transform.position, 10, 0, ForceMode.Impulse);
                if(canDamagePlayer == true && pI.playerIsSafe == false)
                {
                    PlayerHealth.playersHealth -= 10;
                    canDamagePlayer = false;
                    StartCoroutine(invFrames());
                }
                
            }
        }
    }
    IEnumerator invFrames()
    {
        //print("before");
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        this.GetComponent<Renderer>().material = transMat;
        this.GetComponent<EnemyCleanup>().canBeHurt = false;
        yield return new WaitForSeconds(1);
        canDamagePlayer = true;
        this.GetComponent<EnemyCleanup>().canBeHurt = true;
        this.GetComponent<Renderer>().material = mainMat;
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        //print("after");

    }
}


/*
 * 
 * 
 *         if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 0.6f) || Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 0.6f))
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

 * public class ShootingEnemy : MonoBehaviour {
    public GameObject[] bulletBalls;
    public Transform target;
    //public GameObject bulletBalls;
    // Use this for initialization
    void Start () {
        InvokeRepeating("SpawnBullets", 1f,2f);
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject bBalls = Instantiate(bulletBalls[0], this.transform.position, Quaternion.identity);

        //GameObject shotBall = Instantiate(bulletBalls, this.transform.position, Quaternion.identity);
        //Instantiate(bulletBalls, this.transform.position, Quaternion.identity);
        //Debug.DrawRay(transform.position, target.position, Color.blue);
    }
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
            else {
                bBalls.GetComponent<Rigidbody>().AddForce(playerPos.x * 600, playerPos.y * 800, 0);
            }
            
            //print(playerPos);
        }

    }
}

*/
