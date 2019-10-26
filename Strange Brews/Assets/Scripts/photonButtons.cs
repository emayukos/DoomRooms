using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class photonButtons : MonoBehaviour
{
	public menuLogic mLogic;

	public InputField createRoomInput, joinRoomInput;

	[System.Obsolete]
	public void onClickCreateRoom()
	{
		if(createRoomInput.text.Length >= 1) // checks if we typed anything in out input
			_ = PhotonNetwork.CreateRoom(createRoomInput.text, new RoomOptions() { MaxPlayers = 2 }, null);
				Debug.Log("room created!");
	}
	
	public void onClickJoinRoom()
	{
		PhotonNetwork.JoinRoom(joinRoomInput.text);
	}

	
	[System.Obsolete]
	private void OnJoinedRoom() {
		mLogic.disableMenuUI();
		Debug.Log("We are connected to the room!");
	}
	
	
}
