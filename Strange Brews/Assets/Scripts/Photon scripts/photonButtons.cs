using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class photonButtons : MonoBehaviour
{
	public photonHandler pHandler;

	public InputField createRoomInput, joinRoomInput;
    
    // when the button is clicked, create the game 
	//[System.Obsolete]
	public void onClickCreateRoom()
	{
        pHandler.createNewRoom();
	}
	
    // allows a player to join a previously created room? 
	public void onClickJoinRoom()
	{
        pHandler.joinOrCreateRoom();
	}

    // should we add a limit to the number of players in the game? 

    

	
	
}
