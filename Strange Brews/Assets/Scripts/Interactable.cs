using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
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
