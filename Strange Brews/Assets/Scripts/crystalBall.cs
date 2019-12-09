using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// emma
public class crystalBall : MonoBehaviour
{
    private bool inRange, isOpen, connected;
    // counts the number of players are connected to this crystal ball
    private int thisIsOpen; 

    private AudioSource source;
    public AudioClip connectedSound;

    private PhotonView photonView;
    public GameObject UIConnecting, UIConnected; // these are the different UI's
    public crystalBallGroup group; // this is the group of crystal balls

    private int attempts;
    public string hint1 = "Maybe it connects to someone...";
    public string hint2 = "Maybe it we both have to look at them...";
    public messageBox text;

    // Start is called before the first frame update
    void Start()
    {
        UIConnecting.SetActive(false);
        UIConnected.SetActive(false);
        source = GetComponent<AudioSource>();
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isOpen)
            {
                openUI();
            }
            else
            {
                closeUI();
            }           
        }


        // check to see if the other player has the crystal ball open
        if (group.isConnected() != connected && isOpen)
        {
            openUI();
        }

        
    }

    [PunRPC]
    public void isOpenForOther()
    {
        thisIsOpen++;
    }

    [PunRPC]
    public void isNotOpenForOther()
    {
        thisIsOpen--;
        if (thisIsOpen < 0) thisIsOpen = 0;
    }


    public void openUI()
    {
        if (isOpen == false)
        {
            // adds 1 to the number of people connect for both players
            photonView.RPC("isOpenForOther", PhotonTargets.All);

            attempts++;
            if(attempts > 3 && attempts < 6)
            {
                text.SendToTextBox(hint1);
            }
            if(attempts >= 6)
            {
                text.SendToTextBox(hint2);
            }
        }
        // now open
        isOpen = true;

        if (group.isConnected())
        {
            source.PlayOneShot(connectedSound);
            UIConnected.SetActive(true);
            UIConnecting.SetActive(false);
            connected = true;
        }
        else
        {
            UIConnected.SetActive(false);
            UIConnecting.SetActive(true);
            connected = false; 
        }
    }

    

    public void closeUI()
    {
        // close both
        UIConnected.SetActive(false);
        UIConnecting.SetActive(false);
        if (isOpen)
        {
            photonView.RPC("isNotOpenForOther", PhotonTargets.All);
        }
        isOpen = false;
    }

    
    public bool isItOpen()
    {
        return thisIsOpen > 0;
    }


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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PhotonView>().isMine)
            {
                inRange = false;
                closeUI();
            }
        }
    }
}
