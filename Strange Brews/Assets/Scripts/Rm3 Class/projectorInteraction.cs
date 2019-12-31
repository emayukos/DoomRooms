using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectorInteraction : MonoBehaviour
{
    // Get both states of the projector
    public Sprite projOff;
    public Sprite projOn;
    // Check if the player is in range
    private bool inRange;
    // Get the projector screen object that will be "pulled down"
    public GameObject projectorScreen;
    // Used to check if the projector is on or off
    private bool isOn = false;
    // Get the AudioSource object for sounds
    private AudioSource projectorOnAudio;
    // Getting the network text box for messages that is already attached
    GameObject networkTextBox;
    // Create photon view so the other play sees these changes
    private PhotonView photonView;


    //void turnOnProjectorRPC() { }
    // Start is called before the first frame update
    void Start()
    {
        // Make sure the projector screen is not showing at the start
        projectorScreen.SetActive(false);
        // Set up audio object, message box and photon view
        projectorOnAudio = GetComponent<AudioSource>();
        networkTextBox = GameObject.Find("Network Message Text");
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Checking if the player is interacting with the projector (pressing E)
        if (inRange && Input.GetKeyDown(KeyCode.E)) // make icon that says "press E" to open
        {
            // If the projector is on, turn is off
            if (isOn)
            {
                photonView.RPC("TurnOffProjector", PhotonTargets.All);
                TurnOffProjector();
                networkTextBox.GetComponent<messageBox>().photonView.RPC(
                    "MessageDisplayLook", PhotonTargets.All, "The projector has been turned off!");
            }
            // If the projector is off, turn is on
            else
            {
                // Turn on projector on both players screens
                photonView.RPC("TurnOnProjector", PhotonTargets.All);
                // Send message to both players message boxes
                networkTextBox.GetComponent<messageBox>().photonView.RPC(
                    "AddText", PhotonTargets.All, "The projector has been turned on!");
            }
        }


    }

    // Used to change the bool inRange if player is in range of the object
    private void OnTriggerEnter2D(Collider2D col)
    {
        // Have to check which player it is when using Photon
        if (col.gameObject.CompareTag("Player") )
        {
            if (col.GetComponent<PhotonView>().isMine)
            {
                inRange = true;
            }
            
        } else
        {
            Debug.Log("OnTriggerEnter comaring tag isn't player");
        }
    }

    // Used to change the bool inRange if player has left the range of the object
    private void OnTriggerExit2D(Collider2D col)
    {
        // Have to check which player it is when using Photon
        if (col.gameObject.CompareTag("Player"))
        {
            if (col.GetComponent<PhotonView>().isMine)
            {
                inRange = false;
            }
                
        }
        else
        {
            Debug.Log("OnTriggerExit comaring tag isn't player");
        }
    }

    // Called when player is in range and presses "e" if isOn is false
    [PunRPC]
    void TurnOnProjector()
    {
        // Change the projector sprite to the one that's "on"
        // and pulled down projector screen and play the sound
        GetComponent<SpriteRenderer>().sprite = projOn;
        projectorScreen.SetActive(true);
        projectorOnAudio.Play();
        // Change this bool to true
        isOn = true;
    }

    // Called when player is in range and presses "e" if isOn is true
    [PunRPC]
    void TurnOffProjector()
    {
        //Turn off projector
        if (isOn)
        {
            // Change the projector sprite to the one that's "off"
            // and pulled up projector screen and turn off sound
            GetComponent<SpriteRenderer>().sprite = projOff;
            projectorScreen.SetActive(false);
            // Change this bool to false
            isOn = false;
            projectorOnAudio.Pause();
        }
    }


}
