﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightFollow : MonoBehaviour
{
    //Altered from CameraFollow
    //CameraFollow CREDIT TO: Unity Tutorial page https://learn.unity.com/tutorial/movement-basics?projectId=5c514956edbc2a002069467c#

    public GameObject playerThis;        //Public variable to store a reference to the player game object
    public PhotonView photonView;

    private bool On = false;            //Private variable to store the current position for the flashlight to follow

    public Rigidbody2D rbody;
    float sightRotation = 0.0f;


    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        sightRotate(v, h);
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if (On)
        {
            transform.position = playerThis.transform.position;
            //transform.rotation = playerThis.transform.rotation;
            //Debug.Log(sightRotation);
            rbody.MoveRotation(sightRotation);
        }

    }

    [PunRPC]
    public void activateLight(GameObject player)
    {
        playerThis = player;
        On = true;
    }

    public bool isOn()
    {
        return On;
    }

    private void sightRotate(float v, float h)
    {
        if (v == 0)
        {
            if (h < 0)
            {
                //left
                sightRotation = 180f;
            }
            if (h > 0)
            {
                //right
                sightRotation = 0f;
            }
        }
        else if (h == 0)
        {
            if (v > 0)
            {
                //up
                sightRotation = 90f;
            }
            if (v < 0)
            {
                //down
                sightRotation = -90f;
            }
        }
        else
        {
            if (v > 0)
            {
                //diag up
                if (h < 0)
                {
                    //diag up left
                    sightRotation = 135f;
                }
                if (h > 0)
                {
                    //diag up right
                    sightRotation = 45f;
                }
            }
            if (v < 0)
            {
                //diag down
                if (h < 0)
                {
                    //diag down left
                    sightRotation = -135f;
                }
                if (h > 0)
                {
                    //diag down right
                    sightRotation = -45f;
                }
            }
        }
    }
}