using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Photon.MonoBehaviour
{
    private bool HasFinalKey = false;
    private string[] itemlist = new string[3];
    private int numItems = 0;
    GameObject inventoryMenuText;

    // Start is called before the first frame update
    void Start()
    {
        inventoryMenuText = GameObject.Find("Inventory List");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (numItems == 0)
            {
                Debug.Log("empty");
            }
            else
            {
                for (int i = 0; i < numItems; i++)
                {
                    Debug.Log((i + 1) + ". " + itemlist[i]);
                }
            }
            
            
        }


    }

    public bool full()
    {
        if (numItems < 3)
            return false;
        else
            return true;
    }

    public void addItem(string itemName)
    {
        if (!full())
        {
            itemlist[numItems] = itemName;
            numItems++;

            inventoryMenuText.GetComponent<InteractText>().photonView.RPC("AddText", PhotonTargets.All, itemName);

            //Debug.Log(itemName);
            if (itemName == "Final Key"){
                HasFinalKey = true;
            }
        }
        else
        {
            Debug.Log("inventory is full");
        }
    }

    public bool searchItem(string itemName)
    {
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

    public bool hasFinalKey()
    {
        return HasFinalKey;
    }

}
