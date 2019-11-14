using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKey : InventoryItem
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Interactable>().setLookDescription("A very important looking key.");
        GetComponent<InventoryItem>().setItemName("Final Key");
        
    }

}
