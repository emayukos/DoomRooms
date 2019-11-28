using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKeyT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Interactable>().setLookDescription("An important looking key.");
        GetComponent<InventoryItem>().setItemName("Exit Key A");
    }

}
