using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fileCabinet : MonoBehaviour
{
    // Get both the open and closed file cabinet sprites
    public Sprite fileCabinetClosed;
    // The open file cabinet is a game object so it can be set to active and deactive
    public GameObject fileCabinetOpen;
    // Get the projector panel UI object so it can read this script
    public GameObject panelUI;
    // Get the key object
    public GameObject classRoomKey;


    // Define a bool for if the player is in range
    // and if the file cabinet is locked
    private bool inRange, isUnlocked;

    // Define a string to be shown when a player tries to open
    // the locked cabinet
    public string lockedText = "Its locked...";
    // Get the message box for this room, to send messages to
    public messageBox text;
    // Get the audio sources
    public AudioClip lockedSound;
    private AudioSource source;


    public void Awake()
    {
        // set the key to be invisible when the game is rendered 
        classRoomKey.SetActive(false);
        // Get the audio source component
        source = GetComponent<AudioSource>();
    }

    // This function changes the current, closed file cabinet to the open file cabinet
    // This function is used in another script and can be accessed through a Photon Network
    [PunRPC]
    private void openFileCabinet()
    {
        GetComponent<SpriteRenderer>().sprite = fileCabinetOpen.GetComponent<SpriteRenderer>().sprite;
        // Make sure the open file cabinet is placed correctly
        transform.localScale = fileCabinetOpen.transform.localScale;
        transform.position = fileCabinetOpen.transform.position;
        // Turn off the projector panel UI
        panelUI.SetActive(false);
        // Set the key to active
        classRoomKey.SetActive(true);
        // Changes the file cabinet to unlocked
        isUnlocked = true;
    }

    void Update()
    {
        // If player is in range of the object and presses "e"...
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            // And the file cabinet is locked,
            // Send a message to the message box telling them its locked
            if (!isUnlocked)
            {
                text.GetComponent<messageBox>().SendToTextBox(lockedText);
                source.PlayOneShot(lockedSound);
            }
            
        }


    }

    // When the player is in range of the object change the bool to true
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PhotonView>().isMine)
            {
                inRange = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PhotonView>().isMine)
            {
                inRange = true;
            }
        }
    }

    // When the player has left the range of the object change the bool to false
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PhotonView>().isMine)
            {
                inRange = false;
            }
        }
    }
}
