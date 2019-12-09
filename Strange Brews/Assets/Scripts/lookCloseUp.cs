using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// emma
// a script for opening a UI for an object
public class lookCloseUp : MonoBehaviour
{

    private AudioSource source;
    public AudioClip openSoundEffect, closeSoundEffect;

    private bool isIn = false; // to keep track of if the player is in range
    private bool UIopen = false; // the UI is not initially open

    [SerializeField]
    GameObject objectUI;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        // the up close should not be active at the beginning
        objectUI.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (isIn && Input.GetKeyDown(KeyCode.E))
        {
            // if e is pressed when the user is in range then
            // either the UI close up view is opened or closed
            if (UIopen == false)
            {
                // play the opening sound effect, if there is one, when opened
                if (openSoundEffect != null)
                {
                    source.PlayOneShot(openSoundEffect);
                }
                
                objectUI.SetActive(true);
                UIopen = !UIopen;
            }
            else
            {
                // play the closing sound effect, if there is one, when closed
                if (closeSoundEffect != null)
                {
                    source.PlayOneShot(closeSoundEffect);
                }
                objectUI.SetActive(false);
                UIopen = !UIopen;
            }
        }

    }


    // these determine if the player is in the collision area
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<PhotonView>().isMine)
            {
                isIn = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<PhotonView>().isMine)
            {
                // moving out of range will also close the close up view
                isIn = false;
                objectUI.SetActive(false);
                UIopen = false;
            }
        }
    }
}
