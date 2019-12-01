using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // for the changing of the scenes

public class MainMenu : MonoBehaviour
{
    
    //public PhotonNetwork PN;

    // To change the scene when the play button is clicked
    // make sure that this is called when the play button is clicked
    public void PlayGame()
    {
        // this just moves it to the next scene in the queue
        // add to the queue in file/build settings
        PhotonNetwork.automaticallySyncScene = true;
        PhotonNetwork.LoadLevelAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene();

    }

    // To quit the game
    // Hook this up to the quit button
    public void QuitGame()
    {
        // this won't quit in Unity so this is to know it happened
        Debug.Log("Quit");
        Application.Quit();
    }

   
}

