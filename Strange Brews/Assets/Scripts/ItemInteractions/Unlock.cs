using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    public PhotonView photonView;
    GameObject inventory;
    GameObject personalTextBox;
    GameObject networkTextBox;

    private string lockedThingFound = null;
    private string lockedThingKey = null;
    private bool unlock = false;


    void Start()
    {
        //find fixed game objects that will be updated with interactions
        inventory = GameObject.Find("Inventory");
        personalTextBox = GameObject.Find("Personal Message Text");
        networkTextBox = GameObject.Find("Network Message Text");
    }

    void Update()
    {
        if (lockedThingFound != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //true if the required item is in the inventory
                unlock = inventory.GetComponent<Inventory>().searchItem(lockedThingKey);

                
                if(unlock == true)
                {
                    //record unlocking action in 2-player log, then perform unlocking action
                    networkTextBox.GetComponent<ShowNewMessage>().setHaveNewMessage();
                    networkTextBox.GetComponent<InteractText>().photonView.RPC("DisplayLook", PhotonTargets.All, lockedThingFound);
                    this.photonView.RPC("unlockThing", PhotonTargets.All);
                }
                else
                {
                    //required item is not in the inventory, let the local player know
                    Debug.Log("This needs a key.");
                    personalTextBox.GetComponent<ShowNewMessage>().setHaveNewMessage();
                    personalTextBox.GetComponent<InteractText>().DisplayLook("This needs a key.");
                }
                
            }
        }
    }


    void OnTriggerEnter2D(Collider2D col)   //col -> other thing was collided with, if attached to coin -> col = player
    {
        if (col.gameObject.CompareTag("Player"))
        {
            lockedThingKey = GetComponent<AssignedKey>().getKeyName();
            lockedThingFound = GetComponent<AssignedKey>().getUnlockDescription();
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        lockedThingKey = null;
        lockedThingFound = null;
    }

    [PunRPC]
    private void unlockThing()
    {
        //currently just destroys unlocked object
        //later, add more complex animation/image and collider change effects
        PhotonNetwork.Destroy(gameObject);
    }

}
