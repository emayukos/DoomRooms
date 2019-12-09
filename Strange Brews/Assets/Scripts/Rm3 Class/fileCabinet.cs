using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fileCabinet : MonoBehaviour
{

    public Sprite fileCabinetClosed;
    public GameObject fileCabinetOpen;
    public GameObject panelUI;
    public GameObject classRoomKey;



    private bool inRange, isUnlocked;

    public string lockedText = "Its locked...";
    public messageBox text;
    public AudioClip lockedSound;
    private AudioSource source;


    public void Awake()
    {
        // set the key to be invisible when the game is rendered 
        classRoomKey.SetActive(false);
        source = GetComponent<AudioSource>();
    }
    [PunRPC]
    private void openFileCabinet()
    {
        GetComponent<SpriteRenderer>().sprite = fileCabinetOpen.GetComponent<SpriteRenderer>().sprite;
        transform.localScale = fileCabinetOpen.transform.localScale;
        transform.position = fileCabinetOpen.transform.position;
        panelUI.SetActive(false);
        classRoomKey.SetActive(true);

        isUnlocked = true;
    }

    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isUnlocked)
            {
                text.GetComponent<messageBox>().SendToTextBox(lockedText);
                source.PlayOneShot(lockedSound);
            }
            
        }


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
            }
        }
    }
}
