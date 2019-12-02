using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystalBall : MonoBehaviour
{

    private bool inRange, isOpen, otherIsOpen;
    private AudioSource source;

    public AudioClip connectedSound;

    public crystalBall otherCrystalBall;

    public GameObject UIConnecting;
    public GameObject UIConnected;

    private bool connected;

    private PhotonView photonView;

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
                if (connected == true) openConnectedUI();
                else openConnectingUI();
            }
            
            if (isOpen) closeUI();

            isOpen = !isOpen;

            if (isOpen) photonView.RPC("isOpenForOther", PhotonTargets.All);
            else photonView.RPC("isNotOpenForOther", PhotonTargets.All);
            
        }


        // check to see if the other player has the crystal ball open
        if (otherCrystalBall.isItOpen() == true && connected == false)
        {
            connected = true;
            if (isOpen) openConnectedUI();
        }
        else if (otherCrystalBall.isItOpen() == false && connected == true)
        {
            connected = false;
            if (isOpen) openConnectingUI();
        }

        
    }

    [PunRPC]
    void isOpenForOther()
    {
        otherIsOpen = true;
    }

    [PunRPC]
    void isNotOpenForOther()
    {
        otherIsOpen = false;
    }

    

    public void openConnectingUI()
    {
        UIConnecting.SetActive(true);
        UIConnected.SetActive(false);
    }

    public void openConnectedUI()
    {
        if (connectedSound != null) source.PlayOneShot(connectedSound);
        UIConnected.SetActive(true);
        UIConnecting.SetActive(false);
    }

    

    public void closeUI()
    {
        // close both
        UIConnected.SetActive(false);
        UIConnecting.SetActive(false);

    }

    
    public bool isItOpen()
    {
        return otherIsOpen;
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
