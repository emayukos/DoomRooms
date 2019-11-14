﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : Photon.MonoBehaviour
{
    //public PolygonCollider2D player; // move player object into this variable in Unity >> want to change scenes when player touches door and has key
    private int roomNumber = 1;
    public Text roomNumberText;
    public Door controller; // might need this might not
    public Inventory Inventory;

    private void Start()
    {
        //Fetch the GameObject's Collider (make sure they have a Collider component)
        roomNumberText.text = "Room: " + roomNumber;
        //player = GetComponent<PolygonCollider2D>();
        //player.isTrigger = false; // player doesn't have key so not a trigger >> need to set this to true once player has key
    }

    void OnTriggerEnter2D(Collider2D col) // if this doesn't work revert back to on collision enter (need to check trigger)
    {
        if (col.gameObject.CompareTag("Player")) // will only recognize this when the player has the key and is a trigger
        {
            Debug.Log("Player touched door.");
            //if(Inventory.hasFinalKey())
            //{
                Debug.Log("Player has key.");
                roomNumber += 1;
                roomNumberText.text = "Room: " + roomNumber; // update text 
                SceneManager.LoadScene("Room2"); // name of scene >> will destroy this game object
            //}
            //else {
                //Debug.Log("Player doesn't have key.");
            //}
        }
    }
}
