using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : Interactable
{
    //variable(s) for items that can be picked up and put in inventory

    public string itemName;


    public string getItemName()
    {
        return itemName;
    }

    public void setItemName(string name)
    {
        itemName = name;
    }

}
