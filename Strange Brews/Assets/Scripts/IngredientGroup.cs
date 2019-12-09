using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// emma
public class IngredientGroup : MonoBehaviour
{
    // the text boxes in the UI
    public GameObject questionMark, ingredientGroup;
    public Toggle item1, item2; // the toggles for both the items
    public bool isItem1; // if the correct item is the first one

    private void Start()
    {
        // hide the ingredients in the cauldron until they get both the ingredients
        ingredientGroup.SetActive(false);
    }

    // if the ingredients have been found then it activates the item options
    public void foundIngredients()
    {
        questionMark.SetActive(false);
        ingredientGroup.SetActive(true);
    }

    // check if this group is correct based on the boolean
    public bool isCorrect()
    {
        if (item1.isOn == isItem1 && item2.isOn == !isItem1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
