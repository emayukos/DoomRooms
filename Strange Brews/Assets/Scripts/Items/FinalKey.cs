using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKey : InventoryItem
{

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Interactable>().setLookDescription("A very important looking key.");
        GetComponent<InventoryItem>().setItemName("Final Key");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
