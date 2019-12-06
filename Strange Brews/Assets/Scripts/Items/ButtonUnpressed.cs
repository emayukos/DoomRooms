using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUnpressed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //All Interactable objects
        GetComponent<Interactable>().setLookDescription("Button");
        //All InventoryItem objects
        GetComponent<InventoryItem>().setItemName("Button");
    }

}
