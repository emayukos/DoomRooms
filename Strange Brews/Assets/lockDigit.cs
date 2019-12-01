using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lockDigit : MonoBehaviour
{
    public TextMeshProUGUI digit;
    private int digitInt;

    public void increaseNumber()
    {
        digitInt = int.Parse(digit.text);
        digitInt++;
        if (digitInt >= 10) digitInt = 0;
        digit.text = digitInt.ToString();

    }

    public void decreaseNumber()
    {
        digitInt = int.Parse(digit.text);
        digitInt--;
        if (digitInt <= -1) digitInt = 9;
        digit.text = digitInt.ToString();
    }

    public string getDigit()
    {
        return digit.text;
    }
}
