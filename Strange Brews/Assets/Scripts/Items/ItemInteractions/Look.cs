using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    GameObject personalTextBox;

    private string itemDescription = null;


    void Start()
    {
        //find fixed game objects that will be updated with interactions
        personalTextBox = GameObject.Find("Personal Message Text");
    }

    void Update()
    {
        if (itemDescription != null)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                //display description of looked at object
                Debug.Log(itemDescription);
                personalTextBox.GetComponent<ShowNewMessage>().setHaveNewMessage();
                personalTextBox.GetComponent<InteractText>().DisplayLook(itemDescription);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)   //col -> other thing was collided with
    {
        if (col.gameObject.CompareTag("Player"))
        {
            itemDescription = GetComponent<Interactable>().getLookDescription();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        itemDescription = null;
    }

    
}
