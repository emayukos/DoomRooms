using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //variable(s) for any object that can be interacted with on the simplest level - looking

    protected string lookDescription;


    public string getLookDescription()
    {
        return lookDescription;
    }

    public void setLookDescription(string desc)
    {
        lookDescription = desc;
    }

}
