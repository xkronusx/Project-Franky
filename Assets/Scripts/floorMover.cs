using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorMover : MonoBehaviour {
    public Vector3 positivePosition;
    public Vector3 negativePosition;
    public float speed = 1.0f;
    // Use this for initialization
    void Start () {
        positivePosition = new Vector3(this.transform.position.x, this.transform.position.y + 1, 0);
        negativePosition = new Vector3(this.transform.position.x, this.transform.position.y - 1, 0);
    }
	
	// Update is called once per frame
	void Update () {
        float pingPong = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(negativePosition, positivePosition, pingPong);
    }
}