using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Photon.MonoBehaviour
{
    GameObject inventory;
    GameObject actionTextBox;

    private string itemNameFound = null;
    private string itemDescription = null;


    void Start()
    {
        //find fixed game objects that will be updated with interactions
        inventory = GameObject.Find("Inventory");
        actionTextBox = GameObject.Find("Action Log Text");
    }

    void Update()
    {
        if (itemNameFound != null)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                //adds item to local inventory text box
                //interactionTextBox.GetComponent<InteractText>().DisplayLook("The " + itemNameFound + " was put in the inventory.");

                //adds item to multiplayer inventory text box
                //actionTextBox.GetComponent<InteractText>().photonView.RPC("AddText", PhotonTargets.All, "The " + itemNameFound + " was put in the inventory.");
                
                //add item to inventory, remove from scene
                this.photonView.RPC("pickup", PhotonTargets.All);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)   //col -> other thing was collided with, if attached to coin -> col = player
    {
        if (col.gameObject.CompareTag("Player"))
        {
            itemNameFound = GetComponent<InventoryItem>().getItemName();
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        itemNameFound = null;

    }

    [PunRPC]
    private void pickup()
    {
        //adds item to inventory
        inventory.GetComponent<Inventory>().addItem(itemNameFound);
        //removes physical item object from scene
        PhotonNetwork.Destroy(gameObject);
    }
}
