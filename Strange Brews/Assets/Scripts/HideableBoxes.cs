using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideableBoxes : MonoBehaviour
{
    //handles message boxes for help menu, inventory, and any text for player actions

    public int helpOnOff = 1;   // 1 is On, -1 is Off
    int invOnOff;
    public GameObject helpMenu;
    public GameObject inventoryMenu;
    public GameObject personalMessageBox;
    public GameObject networkMessageBox;

    void Awake()
    {
        //help menu is visible upon entry of first room
        //helpOnOff = 1;
        //inventory is not visible upon entry of any room
        invOnOff = -1;
    }


    void Update()
    {
        //switches indicator from 'on' to 'off' or vice versa when applicable key is hit
        if(Input.GetKeyDown(KeyCode.H))
        {
            helpOnOff = helpOnOff * -1;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            invOnOff = invOnOff * -1;

        }

        //open or closes menu given onOff indicator
        OpenClose(helpMenu, helpOnOff);
        OpenClose(inventoryMenu, invOnOff);

    }

    private void OpenClose(GameObject menu, int onOff)
    {
        if (onOff < 0)
        {
            //turn off help/inventory menu
            menu.SetActive(false);
        }
        if (onOff > 0)
        {
            //turn on help/inventory menu
            menu.SetActive(true);
        }
    }
}
