using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject myCamera;
    public GameObject myPlayer;
    public bool bossFight = false;
    // Use this for initialization
    void Start()
    {
        myCamera.transform.Rotate(30, 0, 0);
        myCamera.transform.position = myPlayer.transform.position + new Vector3(0, 5, -10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        myCamera.transform.position = new Vector3(myCamera.transform.position.x, myPlayer.transform.position.y + 5, -10);
        if (myPlayer.transform.position.x > myCamera.transform.position.x && bossFight == false)
        {
            myCamera.transform.position =  new Vector3(myPlayer.transform.position.x, myPlayer.transform.position.y + 5, -10);
        }
    }
}