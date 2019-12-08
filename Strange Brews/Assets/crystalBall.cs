using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystalBall : MonoBehaviour
{

    private bool inRange, isOpen;
    private AudioSource source;

    private int thisIsOpen;

    public AudioClip connectedSound;

    public crystalBall otherCrystalBall;

    public GameObject UIConnecting;
    public GameObject UIConnected;

    public bool connected;

    private PhotonView photonView;

    public crystalBallGroup group;

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
        //Debug.Log("added to thisIsOpen, now: " + thisIsOpen);
    }

    [PunRPC]
    public void isNotOpenForOther()
    {
        thisIsOpen--;
        if (thisIsOpen < 0) thisIsOpen = 0;
        //Debug.Log("subtracted from thisIsOpen, now: " + thisIsOpen);
    }


    public void openUI()
    {
        if (isOpen == false)
        {
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

        isOpen = true;
        if (group.isConnected())
        {
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
