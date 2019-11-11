using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Interactable>().setLookDescription("A locked cabinet.");
        GetComponent<AssignedKey>().setKeyName("Cabinet Key");
        GetComponent<AssignedKey>().setUnlockDescription("The cabinet has been unlocked.");
    }

}
