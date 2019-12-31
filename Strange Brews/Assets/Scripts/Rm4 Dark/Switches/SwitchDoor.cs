using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoor : MonoBehaviour
{
    //To be attached to a door activated by a switch

    public PhotonView photonView;   //of door this is attached to, for use by relevant switch script
    public GameObject openPos;      //where the door object goes when open (were previously having issues with photon and setActive for some reason)
    private Vector3 closedPosition;
    private Vector3 openPosition;

    private void Awake()
    {
        closedPosition = transform.position;
    }

    private void Start()
    {
        closedPosition = transform.position;
        openPosition = openPos.transform.position;
    }


    //below are used by scripts for switche(s) for the door 
    [PunRPC]
    public void doorClose()
    {
        transform.position = closedPosition;
    }

    [PunRPC]
    public void doorOpen()
    {
        transform.position = openPosition;
    }

}
