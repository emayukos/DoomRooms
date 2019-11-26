using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoor : MonoBehaviour
{
    public PhotonView photonView;
    public GameObject openPos;
    private Vector3 closedPosition;
    private Vector3 openPosition;


    void Awake()
    {
        closedPosition = transform.position;
    }

    private void Start()
    {
        openPosition = openPos.transform.position;
    }


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
