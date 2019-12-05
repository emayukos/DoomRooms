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
        textLine.text += description + "\n";
        timeLeft = showMessageTime;
        Debug.Log(textLine.text);
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
        textLine.text += "\n" + description;
        timeLeft = showMessageTime;
        Debug.Log(textLine.text);
    }

    [PunRPC]
    public void ResetMessageBox()
    {
        textLine.text = "";
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        Debug.Log(timeLeft);
        if (timeLeft < 0)
        {
            photonView.RPC("ResetMessageBox", PhotonTargets.All);
        }
    }

}
