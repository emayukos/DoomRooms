using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : Photon.MonoBehaviour
{
    public GameObject door;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //switch goes down
        //   animate here?

        Debug.Log("Door should open.");
        //door.GetComponent<SwitchDoor>().doorOpen();
        door.GetComponent<SwitchDoor>().photonView.RPC("doorOpen", PhotonTargets.All);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //switch goes up
        //   animate here?

        Debug.Log("Door should close.");
        //door.GetComponent<SwitchDoor>().doorClose();
        door.GetComponent<SwitchDoor>().photonView.RPC("doorClose", PhotonTargets.All);
    }
}
