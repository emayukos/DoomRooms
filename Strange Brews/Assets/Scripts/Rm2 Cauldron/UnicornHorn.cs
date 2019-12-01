using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicornHorn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //All Interactable objects
        GetComponent<Interactable>().setLookDescription("Unicorn Horn");
        //All InventoryItem objects
        GetComponent<InventoryItem>().setItemName("Unicorn Horn"); 
    }


}
