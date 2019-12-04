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
            isOpen = !isOpen;            
        }


        // check to see if the other player has the crystal ball open
        if (group.isConnected() != connected && isOpen)
        {
            openUI();
        }

        
    }

    [PunRPC]
    void isOpenForOther()
    {
        thisIsOpen++;
    }

    [PunRPC]
    void isNotOpenForOther()
    {
        thisIsOpen--;
    }


    public void openUI()
    {
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

        photonView.RPC("isOpenForOther", PhotonTargets.All);
    }

    

    public void closeUI()
    {
        // close both
        UIConnected.SetActive(false);
        UIConnecting.SetActive(false);
        photonView.RPC("isNotOpenForOther", PhotonTargets.All);

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
