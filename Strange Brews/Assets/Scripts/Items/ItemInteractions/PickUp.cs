using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Photon.MonoBehaviour
{
    GameObject inventory;
    GameObject networkTextBox;
	 bool HasFinalKey = false;

    private string itemNameFound = null;
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("pickup");
                //pop-up only when new message to display
                //networkTextBox.GetComponent<ShowNewMessage>().setHaveNewMessage();

                //adds item to multiplayer inventory text box
                networkTextBox.GetComponent<InteractText>().photonView.RPC("DisplayLook", PhotonTargets.All, "The " + itemNameFound + " was put in the inventory.");

                //add item to inventory, remove from scene
                //pickup();
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
        if(itemNameFound == "Final Key")
			{
				HasFinalKey = true;
			}
        //removes physical item object from scene
        //Destroy(gameObject);
        PhotonNetwork.Destroy(gameObject);
        //gameObject.SetActive(false);
       
    }
    
    public bool hasFinalKey()
    {
        return HasFinalKey;
    }
}
