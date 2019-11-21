using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject menu;
    public GameObject optionsmenu;
    private bool isOpen;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { 
            Debug.Log("pressed Escape");
            optionsmenu.SetActive(false);
            isOpen = !isOpen;
            menu.SetActive(isOpen);
        }
    }

    public void Resume()
    {
        Debug.Log("pressed resume");
        isOpen = false;
        menu.SetActive(false);
    }

    public void QuitGame()
    {
        // this won't quit in Unity so this is to know it happened
        Debug.Log("Quit");
        Application.Quit();
    }

}
