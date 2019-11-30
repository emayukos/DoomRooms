using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Interactable>().setLookDescription("There's a ripped piece of paper with numbers on it. Some are missing. I should look closer.");
    }

}
