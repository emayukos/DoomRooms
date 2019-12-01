using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitchenCabinetKey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Interactable>().setLookDescription("A key that has 'Kitchen T' written on it.");
        GetComponent<InventoryItem>().setItemName("Kitchen A Key");
    }

}
