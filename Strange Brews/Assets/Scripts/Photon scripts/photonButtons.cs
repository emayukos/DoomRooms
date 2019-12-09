using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class photonButtons : MonoBehaviour
{
	public photonHandler pHandler;

	public InputField createRoomInput, joinRoomInput;
    
    // when the button is clicked, create the game 
	public void onClickCreateRoom()
	{
        pHandler.createNewRoom();
	}
	
    // allows a player to join a previously created room 
    // added limit for the number of players in photonHandler script
	public void onClickJoinRoom()
	{
        pHandler.joinOrCreateRoom();
	}


    

	
	
}
