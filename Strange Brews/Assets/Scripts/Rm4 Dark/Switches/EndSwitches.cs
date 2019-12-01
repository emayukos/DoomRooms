using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSwitches : MonoBehaviour
{
    public GameObject finalDoorControl;
    public GameObject inventory;
    public int switchNum;
    public string key;
    public bool inRange = false;


    // Update is called once per frame
    void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (inventory.GetComponent<Inventory>().searchItem(key))
            {
                finalDoorControl.GetComponent<FinalDoor>().setSwitchOn(switchNum);
                //finalDoorControl.GetComponent<FinalDoor>().photonView.RPC("setSwitchOn", PhotonTargets.All, switchNum);
            }
        }
        if(!inRange || Input.GetKeyUp(KeyCode.E))
        {
            finalDoorControl.GetComponent<FinalDoor>().setSwitchOff(switchNum);
            //finalDoorControl.GetComponent<FinalDoor>().photonView.RPC("setSwitchOff", PhotonTargets.All, switchNum);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inRange = false;
        }
    }
}
