using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightFollow : MonoBehaviour
{
    //Altered from CameraFollow
    //CameraFollow CREDIT TO: Unity Tutorial page https://learn.unity.com/tutorial/movement-basics?projectId=5c514956edbc2a002069467c#

    public GameObject playerThis;        //Public variable to store a reference to the player game object
    public PhotonView photonView;

    private bool On = false;            //Private variable to store the current position for the flashlight to follow


    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if (On)
        {
            transform.position = playerThis.transform.position;
            transform.rotation = playerThis.transform.rotation;
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
}
