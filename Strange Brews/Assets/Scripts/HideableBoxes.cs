﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideableBoxes : MonoBehaviour
{
    int helpOnOff;
    int invOnOff;
    GameObject helpMenu;
    GameObject inventoryMenu;

    void Awake()
    {
        helpOnOff = 1;
        invOnOff = -1;
    }

    private void Start()
    {
        helpMenu = GameObject.Find("Help Menu");
        inventoryMenu = GameObject.Find("Inventory Menu");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            helpOnOff = helpOnOff * -1;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            invOnOff = invOnOff * -1;
        }

        OpenClose(helpMenu, helpOnOff);
        OpenClose(inventoryMenu, invOnOff);

    }

    private void OpenClose(GameObject menu, int onOff)
    {
        if (onOff < 0)
        {
            //turn off help menu
            menu.SetActive(false);
        }
        if (onOff > 0)
        {
            //turn on help menu
            menu.SetActive(true);
        }
    }
}
