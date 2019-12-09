using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSwitches : MonoBehaviour
{
    public GameObject finalDoorControl;
    public GameObject inventory;
    public int switchNum;   //two switches, need number for array access in finalDoorControl intermediary
    public string key;
    public bool inRange = false;

    public PhotonView thisPhotonView;
    public GameObject wrongLight;
    public GameObject rightLight;


    private void Start()
    {
        wrongLight.SetActive(false);
        rightLight.SetActive(false);
    }


    void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("pressing end switch");
            if (inventory.GetComponent<Inventory>().searchItem(key))
            {
                // If the Final Key for the given button is in the inventory, the button can unlock the door
                //finalDoorControl.GetComponent<FinalDoor>().setSwitchOn(switchNum);    //for offline initial testing
                finalDoorControl.GetComponent<FinalDoor>().photonView.RPC("setSwitchOn", PhotonTargets.All, switchNum);
                thisPhotonView.RPC("rightLightOn", PhotonTargets.All);
            }
            else
            {
                thisPhotonView.RPC("wrongLightOn", PhotonTargets.All);
            }
        }
        if(inRange && Input.GetKeyUp(KeyCode.E))
        {
            //finalDoorControl.GetComponent<FinalDoor>().setSwitchOff(switchNum);    //for offline initial testing
            finalDoorControl.GetComponent<FinalDoor>().photonView.RPC("setSwitchOff", PhotonTargets.All, switchNum);
            thisPhotonView.RPC("rightLightOff", PhotonTargets.All);
            thisPhotonView.RPC("wrongLightOff", PhotonTargets.All);

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
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            inRange = false;
            //finalDoorControl.GetComponent<FinalDoor>().setSwitchOff(switchNum);    //for offline initial testing
            finalDoorControl.GetComponent<FinalDoor>().photonView.RPC("setSwitchOff", PhotonTargets.All, switchNum);
            thisPhotonView.RPC("rightLightOff", PhotonTargets.All);
            thisPhotonView.RPC("wrongLightOff", PhotonTargets.All);
        }
    }

    [PunRPC]
    public void rightLightOn()
    {
        rightLight.SetActive(true);
    }

    [PunRPC]
    public void rightLightOff()
    {
        rightLight.SetActive(false);
    }

    [PunRPC]
    public void wrongLightOn()
    {
        wrongLight.SetActive(true);
    }

    [PunRPC]
    public void wrongLightOff()
    {
        wrongLight.SetActive(false);
    }
}
