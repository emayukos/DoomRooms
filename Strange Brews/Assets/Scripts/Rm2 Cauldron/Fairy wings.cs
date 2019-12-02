using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairywings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    	//All Interactable objects
        GetComponent<Interactable>().setLookDescription("Fairy Wings");
        //All InventoryItem objects
        GetComponent<InventoryItem>().setItemName("Fairy Wings");
        
    }

}
