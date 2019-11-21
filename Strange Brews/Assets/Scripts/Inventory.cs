﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Photon.MonoBehaviour
{
    //private bool HasFinalKey = false;
    private string[] itemlist = new string[10];
    private int numItems = 0;
    GameObject inventoryMenuText;
	public GameObject door;



    void Start()
    {
        inventoryMenuText = GameObject.Find("Inventory List");
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
            //inventoryMenuText.GetComponent<InteractText>().photonView.RPC("AddText", PhotonTargets.All, itemName);

            //checks for item required for room completion, sets status for leaving room if found
            if (itemName == "Final Key"){
				door.SendMessage("HasFinalKey"); // send this to door
                //HasFinalKey = true;
            }
        }
        else
        {
            Debug.Log("inventory is full");
        }
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

    //public bool hasFinalKey()
    //{
    //    return HasFinalKey;
    //}

}
