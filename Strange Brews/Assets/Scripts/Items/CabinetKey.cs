using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetKey : InventoryItem
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Interactable>().setLookDescription("A key with the word 'cabinet' on it.");
        GetComponent<InventoryItem>().setItemName("Cabinet Key");
        
    }

}
