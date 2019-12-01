using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cauldronUI : MonoBehaviour
{
    public bool testing;

    public IngredientGroup group1, group2, group3;

    public string i11, i12, i21, i22, i31, i32;

    private Inventory inventory;

    public PhotonView photonView;

    private bool found1, found2, found3;

    private void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (testing)
        {
            group1.foundIngredients();
            group2.foundIngredients();
            group3.foundIngredients();
        }

        if (!found1 || !found2 || !found3)
        {
            check();
        }
        
    }

    private void check()
    {
        if (inventory.searchItem(i11) && inventory.searchItem(i12))
        {
            group1.foundIngredients();
            found1 = true;
        }
        if (inventory.searchItem(i21) && inventory.searchItem(i22))
        {
            group1.foundIngredients();
            found2 = true;
        }
        if (inventory.searchItem(i31) && inventory.searchItem(i32))
        {
            group1.foundIngredients();
            found3 = true;
        }
    }


    public void pressMix()
    {
        if (group1.isCorrect() && group2.isCorrect() && group3.isCorrect())
        {
            photonView.RPC("brewPotion", PhotonTargets.All);
        }

    }
}
