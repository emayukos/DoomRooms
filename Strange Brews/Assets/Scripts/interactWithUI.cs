using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// emma
// for having an object with a UI
// can press e near an object and it will open or close a UI
public class interactWithUI : MonoBehaviour
{
    private bool inRange, isOpen, isActive;
    public GameObject objectUI;
    public AudioClip openAudio, closeAudio;
    private AudioSource source;

    void Start()
    {
        // hide the UI to start
        objectUI.SetActive(false);
        // start with it active
        isActive = true;
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        // if the UI is active, the player is in range, and they press e
        if (inRange && Input.GetKeyDown(KeyCode.E) && isActive)
        {
            // open or close the UI
            if (!isOpen) openUI();
            if (isOpen) closeUI();
            isOpen = !isOpen;
        }
    }


    public void openUI()
    {
        // if there is a sound effect for opening the UI, play it
        if (openAudio != null) source.PlayOneShot(openAudio);
        objectUI.SetActive(true);
    }

    public void closeUI()
    {
        if (closeAudio != null) source.PlayOneShot(closeAudio);
        objectUI.SetActive(false);
    }

    // activate the UI
    public void activate()
    {
        isActive = true;
    }

    // deactivate the UI
    public void deactivate()
    {
        isActive = false;
        // making sure to close it if it needs to be closed
        objectUI.SetActive(false);
        isOpen = false;
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

    // for when the player leaves the range
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PhotonView>().isMine)
            {
                inRange = false;
                // close the UI
                objectUI.SetActive(false);
                isOpen = false;
            }
        }
    }

}
