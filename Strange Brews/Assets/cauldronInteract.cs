using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cauldronInteract : MonoBehaviour
{

    public GameObject potion1, potion2;
    private interactWithUI iwUI;

    private void Start()
    {
        potion1.SetActive(false);
        potion2.SetActive(false);
        iwUI = GetComponent<interactWithUI>();
    }

    [PunRPC]
    public void brewPotion()
    {
        potion1.SetActive(true);
        potion2.SetActive(true);

        iwUI.deactivate();
    }


}