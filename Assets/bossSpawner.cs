using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSpawner : MonoBehaviour {
    public GameObject levelBoss;
    // Use this for initialization
    void Start () {
        StartCoroutine(waitForPlayerToArrive());

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator waitForPlayerToArrive()
    {
        yield return new WaitForSeconds(10);
        Instantiate(levelBoss, this.transform.position + (transform.right * 2), transform.rotation);
        GameObject.FindGameObjectWithTag("Player").GetComponent<FollowPlayer>().bossFight = true;
    }
}