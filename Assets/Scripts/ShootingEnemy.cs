using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour {
    public GameObject[] bulletBalls;
    //public Transform target;
    public GameObject target;
    //public GameObject bulletBalls;
    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
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
        if (Physics.Linecast(transform.position, target.transform.position))
        {
            //Debug.Log("blocked");
            Debug.DrawRay(transform.position, target.transform.position, Color.blue);
            GameObject bBalls = Instantiate(bulletBalls[0], this.transform.position, Quaternion.identity);
            //print(target.position.x);
            //print(target.position.y);
            Vector3 playerPos = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z).normalized;
            if (target.transform.position.x < this.transform.position.x && target.transform.position.x > 0)
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
