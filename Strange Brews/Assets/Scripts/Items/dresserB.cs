using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dresserB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //All Interactable objects
        GetComponent<Interactable>().setLookDescription("A locked dresser.");

        //All LockedThing objects
        GetComponent<AssignedKey>().setKeyName("Dresser B Key");
        GetComponent<AssignedKey>().setUnlockDescription("The dresser B was unlocked.");
    }

}
