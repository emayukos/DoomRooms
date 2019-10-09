using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public Collider player; // move player object into this variable in Unity >> want to change scenes when player touches door and has key
    private int roomNumber = 1;
    public Text roomNumberText;
    public Door controller; // might need this might not

    private void Start()
    {
        //Fetch the GameObject's Collider (make sure they have a Collider component)
        roomNumberText.text = "room: " + roomNumber;
        player = GetComponent<Collider>();
        player.isTrigger = false; // player doesn't have key so not a trigger >> need to set this to true once player has key
    }

    void OnTriggerEnter2D(Collision2D collisionInfo) // if this doesn't work revert back to on collision enter (need to check trigger)
    {
        // Display what we hit
        string hitObject = collisionInfo.collider.tag; // get the tag of the object we hit
        if (hitObject == "Player") // will only recognize this when the player has the key and is a trigger
        {
            Debug.Log("Player touched door");
            // either increase score by 1000 or decrease it by 1000 and display this on screen after switching scenes 
            //Destroy(collisionInfo.gameObject);
            roomNumber++;
            roomNumberText.text = "room: " + roomNumber; // update text 
            SceneManager.LoadScene("Room2"); // name of scene
        }
}
