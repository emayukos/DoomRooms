using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkIngredients : MonoBehaviour
{
    Inventory inventory;
    bool found1, found2, found3;
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        inventory.searchItem("ingredients1");
        
    }




}
