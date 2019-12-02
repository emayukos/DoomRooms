using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : Photon.MonoBehaviour
{
    public GameObject door;
    public GameObject pressurePadOn;
    public PhotonView thisPhotonView;

    private void Start()
    {
        pressurePadOn.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //switch goes down
        //   animate here?

        if(collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            Debug.Log("Door should open.");
            //door.GetComponent<SwitchDoor>().doorOpen();
            door.GetComponent<SwitchDoor>().photonView.RPC("doorOpen", PhotonTargets.All);
            thisPhotonView.RPC("pressurePadDown", PhotonTargets.All);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        //switch goes up
        //   animate here?
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            Debug.Log("Door should close.");
            //door.GetComponent<SwitchDoor>().doorClose();
            door.GetComponent<SwitchDoor>().photonView.RPC("doorClose", PhotonTargets.All);
            thisPhotonView.RPC("pressurePadUp", PhotonTargets.All);
        }
    }

    [PunRPC]
    public void pressurePadDown()
    {
        pressurePadOn.SetActive(true);
    }

    [PunRPC]
    public void pressurePadUp()
    {
        pressurePadOn.SetActive(false);
    }
}
