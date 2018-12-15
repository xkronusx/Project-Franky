using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserPowerup : MonoBehaviour {
    public Material laserMat;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(30, 15, 45) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.GetComponent<PlayerControls>() != null)
        {
            if (col.GetComponent<PlayerControls>().laserPoweredUp != true)
            {
                col.gameObject.GetComponent<Renderer>().material = laserMat;
                col.GetComponent<PlayerControls>().laserPoweredUp = true;
                col.GetComponent<laserPowerUpTimer>().enabled = true;
                //StartCoroutine(col.GetComponent<PlayerControls>().laserTimer());
            }
            Destroy(this.gameObject);
        }
    }
}
