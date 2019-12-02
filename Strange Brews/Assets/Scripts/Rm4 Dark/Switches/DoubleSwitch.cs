using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSwitch : MonoBehaviour
{
    public GameObject doorOutside;
    public GameObject doorMiddle;
    public GameObject doorCage;

    private bool inRange;
    private bool outsideDoorsOpen;
    private bool middleDoorOpen;

    private void Start()
    {
        outsideDoorsOpen = false;
        middleDoorOpen = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            if (outsideDoorsOpen)
            {
                Debug.Log("Outside doors should close.");
                //doorOutside.GetComponent<SwitchDoor>().doorClose();
                //doorCage.GetComponent<SwitchDoor>().doorClose();
                doorOutside.GetComponent<SwitchDoor>().photonView.RPC("doorClose", PhotonTargets.All);
                doorCage.GetComponent<SwitchDoor>().photonView.RPC("doorClose", PhotonTargets.All);
                outsideDoorsOpen = !outsideDoorsOpen;
            }
            else
            {
                Debug.Log("Outside doors should open.");
                //doorOutside.GetComponent<SwitchDoor>().doorOpen();
                //doorCage.GetComponent<SwitchDoor>().doorOpen();
                doorOutside.GetComponent<SwitchDoor>().photonView.RPC("doorOpen", PhotonTargets.All);
                doorCage.GetComponent<SwitchDoor>().photonView.RPC("doorOpen", PhotonTargets.All);
                outsideDoorsOpen = !outsideDoorsOpen;
            }

            if (middleDoorOpen)
            {
                //doorMiddle.GetComponent<SwitchDoor>().doorClose();
                doorMiddle.GetComponent<SwitchDoor>().photonView.RPC("doorClose", PhotonTargets.All);
                middleDoorOpen = !middleDoorOpen;
            }
            else
            {
                //doorMiddle.GetComponent<SwitchDoor>().doorOpen();
                doorMiddle.GetComponent<SwitchDoor>().photonView.RPC("doorOpen", PhotonTargets.All);
                middleDoorOpen = !middleDoorOpen;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //switch goes down
        //   light change call here?

        if(collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //switch goes up
        //   light change call here?

        if(collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            inRange = false;
        }
    }
}
