using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Photon.MonoBehaviour
{
    private string[] itemlist = new string[30];
    private int numItems = 0;
    private string inventoryList = "";
    public GameObject inventoryMenuText;


    void Start()
    {

    }


    public bool full()
    {
        //checks if inventory array capacity has been met
        if (numItems < 3)
            return false;
        else
            return true;
    }
    [PunRPC]
    public void addItem(string itemName)
    {
        if (!full())
        {
            //adds items to next open position in inventory array
            itemlist[numItems] = itemName;
			Debug.Log(itemName);
            numItems++;

            //adds item to inventory display list
            //inventoryMenuText.GetComponent<InteractText>().DisplayLook(InventoryToString());
            inventoryMenuText.GetComponent<InteractText>().photonView.RPC("DisplayLook", PhotonTargets.All, InventoryToString());
        }
        else
        {
            Debug.Log("inventory is full");
        }
    }


    [PunRPC]
    public void removeItem(string itemName)
    {
        int i = 0;
        bool notFound = true;

        while (notFound == true && i < numItems)
        {
            if (itemlist[i] == itemName)
            {
                notFound = false;
                numItems--;
            }
            else
            {
                i++;
            }
            
        }
        while (i < numItems)
        {
            itemlist[i] = itemlist[i + 1];
            i++;
        }

        inventoryMenuText.GetComponent<InteractText>().photonView.RPC("DisplayLook", PhotonTargets.All, InventoryToString());
    }


    [PunRPC]
    public bool searchItem(string itemName)
    {
        //searches for a provided item name in the inventory array
        //returns true if item found

        bool isFound = false;
        int i = 0;
        while (!isFound && i<numItems)
        {
            if (itemlist[i] == itemName)
            {
                isFound = true;
            }
        }
        return isFound;
    }

    private string InventoryToString()
    {
        if(numItems == 0)
        {
            inventoryList = "";
        }

        for (int i=0; i < numItems; i++)
        {
            inventoryList += "\n" + itemlist[i];
        }

        return inventoryList;
    }
}
