using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGeneration : MonoBehaviour {
    public GameObject startFloor;
    public GameObject[] listOfFloors;
    public int floorChoice;
    public GameObject currFloor;
    public GameObject beforeFloor;
    public int numOfFloors = 15;
    public int numOfSpawnedFloors;
    public GameObject bossFloor;
    public GameObject endFloor;
    public bool bossDefeated = false;
    public bool endSpawned = false;
    // Use this for initialization
    void Start () {
        floorChoice = Random.Range(0,listOfFloors.Length);
        beforeFloor = startFloor;
        currFloor = Instantiate(listOfFloors[floorChoice], startFloor.transform.position + (transform.right * 20), transform.rotation);
        numOfSpawnedFloors++;
    }
	
	// Update is called once per frame
	void Update () {
        if (Camera.main.transform.position.x > currFloor.transform.position.x && numOfSpawnedFloors < numOfFloors) {
            Destroy(beforeFloor.gameObject);
            beforeFloor = currFloor;
            floorChoice = Random.Range(0, listOfFloors.Length);
            currFloor = Instantiate(listOfFloors[floorChoice], beforeFloor.transform.position + (transform.right * 20), transform.rotation);
            //currFloor.AddComponent<enemySpawner>();
            numOfSpawnedFloors++;
        }
        if (numOfSpawnedFloors == numOfFloors) {
            Instantiate(bossFloor, currFloor.transform.position + (transform.right * 20), transform.rotation);
            numOfSpawnedFloors++;
            //print(beforeFloor.transform.position);
            //print(currFloor.transform.position);
            //print(bossFloor.transform.position);
        }
        if (bossDefeated == true && endSpawned == false)
        {
            print(bossFloor.transform.position);
            Instantiate(endFloor, currFloor.transform.position + (transform.right * 40), transform.rotation);
            endSpawned = true;
        }
    }
}
