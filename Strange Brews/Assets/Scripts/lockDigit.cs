using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// emma
// for the chest digits
public class lockDigit : MonoBehaviour
{
    public TextMeshProUGUI digit;
    private int digitInt;

    // gets called when the up arrow is pressed
    public void increaseNumber()
    {
        digitInt = int.Parse(digit.text);
        digitInt++;
        // loop it back around if it has reached the max
        if (digitInt >= 10) digitInt = 0;
        // update the number
        digit.text = digitInt.ToString();

    }

    // gets called when the down arrow is pressed
    public void decreaseNumber()
    {
        digitInt = int.Parse(digit.text);
        digitInt--;
        // loop it back around if it has reached the min
        if (digitInt <= -1) digitInt = 9;
        // update the number
        digit.text = digitInt.ToString();
    }

    // for checking the number
    public string getDigit()
    {
        return digit.text;
    }
}
