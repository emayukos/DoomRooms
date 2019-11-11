using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractText : MonoBehaviour
{
    public PhotonView photonView;
    public Text textLine;

    [PunRPC]
    public void DisplayLook(string description)
    {
        textLine.text = description;
    }

    [PunRPC]
    public void AddText(string description)
    {
        textLine.text += "\n" + description;
    }


}
