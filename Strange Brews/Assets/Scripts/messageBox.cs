using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// emma
// for changing or adding text to the message box
// has a timer on them so they clear
public class messageBox : MonoBehaviour
{
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
        // add new text to the end of the message
        timeLeft = showMessageTime;
        textLine.text += description + "\n";
        isMessage = true;
    }

    [PunRPC]
    public void UpdateText(string description)
    {
        // reset the message
        timeLeft = showMessageTime;
        textLine.text = description + "\n";
        isMessage = true;
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
        // counts down the time
        timeLeft -= Time.deltaTime;
        // when the time is up, reset the message
        if (timeLeft < 0f && isMessage)
        {
            photonView.RPC("ResetMessageBox", PhotonTargets.All);
        }
        
    }

}
