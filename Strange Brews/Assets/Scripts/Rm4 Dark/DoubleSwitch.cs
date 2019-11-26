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
        doorMiddle.GetComponent<SwitchDoor>().photonView.RPC("doorOpen", PhotonTargets.All);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            if (outsideDoorsOpen)
            {
                Debug.Log("Outside doors should close.");
                doorOutside.GetComponent<SwitchDoor>().photonView.RPC("doorClose", PhotonTargets.All);
                doorCage.GetComponent<SwitchDoor>().photonView.RPC("doorClose", PhotonTargets.All);
            }
            else
            {
                Debug.Log("Outside doors should open.");
                doorOutside.GetComponent<SwitchDoor>().photonView.RPC("doorOpen", PhotonTargets.All);
                doorCage.GetComponent<SwitchDoor>().photonView.RPC("doorOpen", PhotonTargets.All);
            }

            if (middleDoorOpen)
            {
                doorMiddle.GetComponent<SwitchDoor>().photonView.RPC("doorClose", PhotonTargets.All);
            }
            else
            {
                doorMiddle.GetComponent<SwitchDoor>().photonView.RPC("doorOpen", PhotonTargets.All);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //switch goes down
        //   light change call here?

        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //switch goes up
        //   light change call here?

        inRange = false;
    }
}
