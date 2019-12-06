using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestUI : MonoBehaviour
{
    public GameObject thisObject;

    public string code;
    public lockDigit digit1, digit2;

    private int attempts;
    public string hint = "Maybe the owner wrote their password on a scroll";
    public messageBox text;

    public void checkAnswer()
    { 
        if (code == digit1.getDigit() + digit2.getDigit())
        {
            //open box
            Debug.Log("open chest");
            thisObject.GetComponent<interactWithUI>().deactivate();
            thisObject.GetComponent<chest>().openChest();

        }
        attempts++;
        if (attempts > 3)
        {
            text.SendToTextBox(hint);
        }
    }
}
