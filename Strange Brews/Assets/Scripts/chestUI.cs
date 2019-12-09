using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// emma
public class chestUI : MonoBehaviour
{
    // this is the chest
    public GameObject thisObject;

    // set in unity, 16
    public string code;
    // these are the digit fields of the chest
    public lockDigit digit1, digit2;

    private int attempts;
    public string hint = "Maybe the owner wrote their password on a scroll";
    public messageBox text;

    // this gets called when the player presses the enter button
    public void checkAnswer()
    {
        // this counts the attempts the player has made
        attempts++;
        // if the code is correct (checked using strings)
        if (code == digit1.getDigit() + digit2.getDigit())
        {
            Debug.Log("open chest");
            // deactivate the UI so it can't be opened anymore
            thisObject.GetComponent<interactWithUI>().deactivate();
            // open the chest
            thisObject.GetComponent<chest>().openChest();

        }

        // if they have attempted it more than 3 times, show the hint
        else if (attempts > 3)
        {
            // sends it to the text box
            text.SendToTextBox(hint);
        }
    }
}
