using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public GameObject inventory;
    public GameObject interactionTextBox;

    private string itemDescription = null;


    void Start()
    {
        //find fixed game objects that will be updated with interactions
        inventory = GameObject.Find("Inventory");
        interactionTextBox = GameObject.Find("Interaction Text");
    }

    void Update()
    {
        if (itemDescription != null)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                //display description of looked at object
                Debug.Log(itemDescription);
                interactionTextBox.GetComponent<InteractText>().DisplayLook(itemDescription);
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
