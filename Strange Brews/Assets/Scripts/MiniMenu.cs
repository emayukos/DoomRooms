using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// emma
// a script for the mini menu
public class MiniMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject menu, optionsmenu; // the two menus
    private bool isOpen;


    private void Update()
    {
        // if the player presses the escape key
        if (Input.GetKeyDown(KeyCode.Escape)) { 
            Debug.Log("pressed Escape");
            // close the options menu
            optionsmenu.SetActive(false);
            // open or close the menu
            isOpen = !isOpen;
            menu.SetActive(isOpen);
        }
    }

    // these are linked to the buttons
    public void Resume()
    {
        // for when the player presses resume, just closes the menu
        Debug.Log("pressed resume");
        isOpen = false;
        menu.SetActive(false);
    }

    public void QuitGame()
    {
        // will quit the game
        Debug.Log("Quit");
        Application.Quit();
    }

}
