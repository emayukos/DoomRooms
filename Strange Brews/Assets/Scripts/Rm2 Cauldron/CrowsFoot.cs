using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowsFoot : MonoBehaviour
{
    void Start()
    {
        //All Interactable objects
        GetComponent<Interactable>().setLookDescription("Crow's Foot");
        //All InventoryItem objects
        GetComponent<InventoryItem>().setItemName("Crow's Foot");
    }
}
