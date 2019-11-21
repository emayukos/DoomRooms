using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideableBoxes : MonoBehaviour
{
    int helpOnOff;
    int invOnOff;
    public GameObject helpMenu;
    public GameObject inventoryMenu;
    public GameObject personalMessageBox;
    public GameObject networkMessageBox;

    void Awake()
    {
        //help menu is visible upon entry of first room
        helpOnOff = 1;
        //inventory is not visible upon entry of any room
        invOnOff = -1;
    }

    private void Start()
    {

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
        if (Input.GetKeyDown(KeyCode.M))
        {
            personalMessageBox.SetActive(false);
            networkMessageBox.SetActive(false);
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
