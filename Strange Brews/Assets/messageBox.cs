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

    private bool isMessage;

    public void SendToTextBox(string message)
    {
        photonView.RPC("MessageDisplayLook", PhotonTargets.All, message);
    }


    [PunRPC]
    public void MessageDisplayLook(string description)
    {
        //changes Text to show only new text
        timeLeft = showMessageTime;
        textLine.text += description + "\n";
        isMessage = true;
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
        textLine.text += description + "\n";
    }

    [PunRPC]
    public void ResetMessageBox()
    {
        textLine.text = "";
        isMessage = false;
    }

    private void Update()
    {
        
        timeLeft -= Time.deltaTime;
        
        
        if (timeLeft < 0f && isMessage)
        {
            photonView.RPC("ResetMessageBox", PhotonTargets.All);
        }
        
    }

}
