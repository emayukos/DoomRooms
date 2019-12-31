using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractText : MonoBehaviour
{
    //for changing or adding text to a Text box with a PhotonView

    public PhotonView photonView;
    public Text textLine;


    [PunRPC]
    public void DisplayLook(string description)
    {
        Debug.Log("Gets to display look");
        //changes Text to show only new text 
        textLine.text = description;
        Debug.Log(textLine.text);
    }

    [PunRPC]
    public void AddText(string description)
    {
        Debug.Log("Gets to addText");
        //appends new text onto existing display
        textLine.text += "\n" + description;
        Debug.Log(textLine.text);
    }



}
