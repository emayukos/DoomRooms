using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKey : InventoryItem
{

    

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<InventoryItem>().setItemName("Final Key");
        GetComponent<Interactable>().setLookDescription("A very important looking key.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
