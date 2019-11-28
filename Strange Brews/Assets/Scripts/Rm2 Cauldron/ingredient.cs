using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ingredient : MonoBehaviour
{
    public RawImage ingredientPic;
    private bool isOn;

    private void Start()
    {
        ingredientPic.enabled = false;
    }

    public void showIngredient()
    {
        isOn = !isOn;
        ingredientPic.enabled = isOn;
    }
}
