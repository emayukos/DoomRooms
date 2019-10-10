using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetKey : InventoryItem
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<InventoryItem>().setItemName("Cabinet Key");
        GetComponent<Interactable>().setLookDescription("A key with the word 'cabinet' on it.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
