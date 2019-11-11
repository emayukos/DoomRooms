using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Photon.MonoBehaviour
{
    public GameObject inventory;
    GameObject actionTextBox;

    private string itemNameFound = null;
    private string itemDescription = null;
    

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Inventory");
        actionTextBox = GameObject.Find("Action Log Text");
    }

    void Update()
    {
        if (itemNameFound != null)
        {
            
            if (Input.GetKeyDown(KeyCode.G))
            {
                //add to inventory
                //addItem(itemNameFound);
                //interactionTextBox.GetComponent<InteractText>().DisplayLook("The " + itemNameFound + " was put in the inventory.");
                actionTextBox.GetComponent<InteractText>().photonView.RPC("AddText", PhotonTargets.All, "The " + itemNameFound + " was put in the inventory.");
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
        inventory.GetComponent<Inventory>().addItem(itemNameFound);
        PhotonNetwork.Destroy(gameObject);
    }
}
