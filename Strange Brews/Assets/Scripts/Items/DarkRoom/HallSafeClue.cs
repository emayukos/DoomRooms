using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallSafeClue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //All Interactable objects
        GetComponent<Interactable>().setLookDescription("There's only a piece of paper. I should take a closer look.");
    }

}
