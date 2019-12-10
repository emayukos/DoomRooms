using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectorScreen : MonoBehaviour
{
    // Get the projector screen object
    [SerializeField]
    GameObject projectorScreenPanel;

    private bool UIopen = false;
    private bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        // To start, the panel UI needs to be hidden
        projectorScreenPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If player is in range and they press "e" then,
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            // If already open, close the panel UI
            // and set UIopen to true
            if (UIopen == false)
            {
                projectorScreenPanel.SetActive(true);
                UIopen = !UIopen;
            }
            // If closed, open the panel UI
            // and set UIopen to false
            else
            {
  
                projectorScreenPanel.SetActive(false);
                UIopen = !UIopen;
            }
        }
    }

    // Changes inRange to true is player is in range of the object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            if (collision.GetComponent<PhotonView>().isMine)
            {
                inRange = true;
            }

        }
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            if (collision.GetComponent<PhotonView>().isMine)
            {
                inRange = true;
            }

        }
    }
    // Changes inRange to false is player has left range of the object
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        { 
            if (collision.GetComponent<PhotonView>().isMine)
            {
               
                inRange = false;
                projectorScreenPanel.SetActive(false);
                UIopen = false;
            }
            

        }
    }

}
