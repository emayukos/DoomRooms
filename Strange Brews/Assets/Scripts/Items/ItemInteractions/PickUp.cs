using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Photon.MonoBehaviour
{
    GameObject inventory;
    GameObject networkTextBox;

    private string itemNameFound = null;
    private bool inRange = false;
    //private string itemDescription = null;


    void Start()
    {
        //find fixed game objects that will be updated with interactions
        inventory = GameObject.Find("Inventory");
        networkTextBox = GameObject.Find("Network Message Text");
    }

    void Update()
    {
        if (itemNameFound != null)
        {
            if (inRange && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("pickup");
                //pop-up only when new message to display
                //networkTextBox.GetComponent<ShowNewMessage>().setHaveNewMessage();

                //adds item to multiplayer inventory text box
                networkTextBox.GetComponent<InteractText>().photonView.RPC("DisplayLook", PhotonTargets.All, "The " + itemNameFound + " was put in the inventory.");

                //add item to inventory, remove from scene
                //pickup();
                inventory.GetComponent<Inventory>().photonView.RPC("addItem", PhotonTargets.All, itemNameFound);
                //this.photonView.RPC("pickup", PhotonTargets.All);
                this.photonView.RPC("deleteObject", PhotonTargets.All);
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)   //col -> other thing was collided with, if attached to coin -> col = player
    {
        if (col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine)
        {
            itemNameFound = GetComponent<InventoryItem>().getItemName();
			inRange = true;
        }

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine)
        {
            itemNameFound = GetComponent<InventoryItem>().getItemName();
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        itemNameFound = null;
		inRange = false;

    }

    //[PunRPC]
    //private void pickup()
    //{
        //adds item to inventory
        //inventory.GetComponent<Inventory>().photonView.RPC("addItem", PhotonTargets.All, itemNameFound);
        //     if(itemNameFound == "Final Key")
        //{
        //	HasFinalKey = true;
        //}
        //removes physical item object from scene
        //Destroy(gameObject);
        //PhotonNetwork.Destroy(gameObject);
        //gameObject.SetActive(false);

      

    //}

    [PunRPC]
    private void deleteObject()
    {
        Destroy(gameObject);
    }
}
