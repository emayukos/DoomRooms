using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : Interactable
{
    protected string itemName;


    public string getItemName()
    {
        return itemName;
    }

    public void setItemName(string name)
    {
        itemName = name;
    }

}
