using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class photonButtons : MonoBehaviour
{
	public menuLogic mLogic;

	public InputField createRoomInput, joinRoomInput;
	
	public void onClickCreateRoom()
	{
		if(createRoomInput.text.Length >= 1)
			_ = PhotonNetwork.CreateRoom(createRoomInput.text, new RoomOptions() { MaxPlayers = 2 }, null);
			
	}
	
	public void onClickJoinRoom()
	{
		PhotonNetwork.JoinRoom(joinRoomInput.text);
	}
	
	// not working?
	private void OnJoinedRoom() {
		mLogic.disableMenuUI();
		Debug.Log("We are connected to the room!");
	}
	
	
}
