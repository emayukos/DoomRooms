using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystalBall : MonoBehaviour
{

    private bool inRange, isOpen, isActive;
    public GameObject objectUI;
    public AudioClip openAudio, closeAudio;
    private AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        objectUI.SetActive(false);
        isActive = true;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E) && isActive)
        {
            if (!isOpen) openUI();
            if (isOpen) closeUI();
            isOpen = !isOpen;
        }
    }

    public void openUI()
    {
        if (openAudio != null) source.PlayOneShot(openAudio);
        objectUI.SetActive(true);
    }

    public void closeUI()
    {
        if (closeAudio != null) source.PlayOneShot(closeAudio);
        objectUI.SetActive(false);
    }


    public void activate()
    {
        isActive = true;
    }

    public void deactivate()
    {
        isActive = false;
        objectUI.SetActive(false);
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
            }
        }
    }
}
