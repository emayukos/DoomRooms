using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKeyB : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //All Interactable objects
        GetComponent<Interactable>().setLookDescription("There's something shining under the bed.");

        //All Inventory items
        GetComponent<InventoryItem>().setItemName("Exit Key B");
    }

}
