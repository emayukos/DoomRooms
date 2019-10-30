using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Photon.MonoBehaviour
{
    private string itemNameFound = null;
    private string itemDescription = null;
    GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Inventory");
    }

    void Update()
    {
        if (itemNameFound != null)
        {
            
            if (Input.GetKeyDown(KeyCode.G))
            {
                //add to inventory
                //addItem(itemNameFound);
                //pickup();
                this.photonView.RPC("pickup", PhotonTargets.All);
                
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                //display description
                Debug.Log(itemDescription);
            }
            
        }

    }

    void OnTriggerEnter2D(Collider2D col)   //col -> other thing was collided with, if attached to coin -> col = player
    {
        if (col.gameObject.CompareTag("Player"))
        {
            itemNameFound = GetComponent<InventoryItem>().getItemName();
            itemDescription = GetComponent<Interactable>().getLookDescription();
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
