using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitScene : Photon.MonoBehaviour
{
    //simplified scene transition because it's the end and no new puzzle scenes need stuff put in

    bool inRange = false;
    //public Material border;   //hard mode, no borders put on
    //public Material unborder;
    public GameObject levelChanger;
    public Text personalTextBox;


    private void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            // unlock door and go to next room
            levelChanger.SendMessage("FadeToNextLevelRPC");
            Debug.Log("unlocked door");
            //roomNumber += 1;
            //roomNumberText.text = "Room: " + roomNumber; // update text 
            //SceneManager.LoadScene("Room2"); // name of scene >> will destroy this game object
        }
    }

    void OnTriggerEnter2D(Collider2D col) // if this doesn't work revert back to on collision enter (need to check trigger)
    {
        if (col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine) // will only recognize this when the player has the key and is a trigger
        {
            inRange = true;
            Debug.Log("Player touched door.");
            personalTextBox.GetComponent<InteractText>().DisplayLook("Will we leave now?");
            //GetComponent<Renderer>().material = border; // give door border indicating it can be unlocked
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine) // will only recognize this when the player has the key and is a trigger
        {
            inRange = true;
            Debug.Log("Player touched door.");
            personalTextBox.GetComponent<InteractText>().DisplayLook("Will we leave now?");
            //GetComponent<Renderer>().material = border; // give door border indicating it can be unlocked
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        inRange = false;
        personalTextBox.GetComponent<InteractText>().DisplayLook("");
        //GetComponent<Renderer>().material = unborder;
    }

}
