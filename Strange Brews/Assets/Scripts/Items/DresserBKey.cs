using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DresserBKey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //All Interactable objects
        GetComponent<Interactable>().setLookDescription("A key with 'Dresser B' on it");

        //All InventoryItem objects
        GetComponent<InventoryItem>().setItemName("Dresser B Key");
    }

}
