using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class messageBox : MonoBehaviour
{
    //for changing or adding text to the message box

    public PhotonView photonView;
    public Text textLine;

    private float timeLeft;
    public float showMessageTime = 5.0f;


    [PunRPC]
    public void MessageDisplayLook(string description)
    {
        //changes Text to show only new text
        timeLeft = showMessageTime;
        textLine.text += description + "\n";
    }

    [PunRPC]
    public void UpdateText(string description)
    {
        textLine.text = description + "\n";
    }

    [PunRPC]
    public void AddText(string description)
    {
        //appends new text onto existing display
        timeLeft = showMessageTime;
        textLine.text += "\n" + description;
    }

    [PunRPC]
    public void ResetMessageBox()
    {
        textLine.text = "";
    }

    private void Update()
    {
        if (timeLeft > 0f)
        {
            timeLeft -= Time.deltaTime;
        }
        
        if (timeLeft < 0f)
        {
            photonView.RPC("ResetMessageBox", PhotonTargets.All);
        }
        
    }

}
