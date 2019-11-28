using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Interactable>().setLookDescription("A ripped piece of paper with numbers on it. Some are missing.");
    }

}
