using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closedCabinet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //All Interactable objects
        GetComponent<Interactable>().setLookDescription("A locked kitchen cabinet.");

        //All LockedThing objects
        GetComponent<AssignedKey>().setKeyName("Kitchen A Key");
        GetComponent<AssignedKey>().setUnlockDescription("The kitchen cabinet was unlocked.");
    }

}
