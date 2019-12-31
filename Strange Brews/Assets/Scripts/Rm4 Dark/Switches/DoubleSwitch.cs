using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSwitch : MonoBehaviour
{
    //pressure plate switches to open doors in Dark Room bedrooms
    // 3 sets of doors, only outside doors or middle door can be open at one time, like an airlock

    public GameObject doorOutside;
    public GameObject doorMiddle;
    public GameObject doorCage;

    public PhotonView thisPhotonView;
    public GameObject outsideLight;     //light indicators for which doors are currently closed
    public GameObject middleLight;

    private bool inRange;
    private bool outsideDoorsOpen;
    private bool middleDoorOpen;

    private void Start()
    {
        outsideDoorsOpen = false;
        middleDoorOpen = true;
        outsideLight.SetActive(false);
        middleLight.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            if (outsideDoorsOpen)
            {
                Debug.Log("Outside doors should close.");
                //doorOutside.GetComponent<SwitchDoor>().doorClose();   //for offline initial testing
                //doorCage.GetComponent<SwitchDoor>().doorClose();      //for offline initial testing
                doorOutside.GetComponent<SwitchDoor>().photonView.RPC("doorClose", PhotonTargets.All);
                doorCage.GetComponent<SwitchDoor>().photonView.RPC("doorClose", PhotonTargets.All);
                thisPhotonView.RPC("MiddleLightOn", PhotonTargets.All);
                outsideDoorsOpen = !outsideDoorsOpen;
            }
            else
            {
                Debug.Log("Outside doors should open.");
                //doorOutside.GetComponent<SwitchDoor>().doorOpen();    //for offline initial testing
                //doorCage.GetComponent<SwitchDoor>().doorOpen();       //for offline initial testing
                doorOutside.GetComponent<SwitchDoor>().photonView.RPC("doorOpen", PhotonTargets.All);
                doorCage.GetComponent<SwitchDoor>().photonView.RPC("doorOpen", PhotonTargets.All);
                thisPhotonView.RPC("OutsidesLightOn", PhotonTargets.All);
                outsideDoorsOpen = !outsideDoorsOpen;
            }

            if (middleDoorOpen)
            {
                //doorMiddle.GetComponent<SwitchDoor>().doorClose();    //for offline initial testing
                doorMiddle.GetComponent<SwitchDoor>().photonView.RPC("doorClose", PhotonTargets.All);
                middleDoorOpen = !middleDoorOpen;
            }
            else
            {
                //doorMiddle.GetComponent<SwitchDoor>().doorOpen();     //for offline initial testing
                doorMiddle.GetComponent<SwitchDoor>().photonView.RPC("doorOpen", PhotonTargets.All);
                middleDoorOpen = !middleDoorOpen;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            inRange = false;
        }
    }

    [PunRPC]
    private void OutsidesLightOn()
    {
        outsideLight.SetActive(true);
        middleLight.SetActive(false);
    }

    [PunRPC]
    private void MiddleLightOn()
    {
        middleLight.SetActive(true);
        outsideLight.SetActive(false);
    }
}
