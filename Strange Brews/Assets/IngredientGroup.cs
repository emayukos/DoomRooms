using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngredientGroup : MonoBehaviour
{
    public GameObject questionMark;
    public GameObject ingredientGroup;

    public Toggle item1;
    public Toggle item2;

    public bool isItem1;

    private void Start()
    {
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
