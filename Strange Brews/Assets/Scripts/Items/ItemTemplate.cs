using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTemplate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //All Interactable objects
        GetComponent<Interactable>().setLookDescription("");

        //All InventoryItem objects
        GetComponent<InventoryItem>().setItemName("");

        //All LockedThing objects
        GetComponent<AssignedKey>().setKeyName("");
        GetComponent<AssignedKey>().setUnlockDescription("");

    }

}
