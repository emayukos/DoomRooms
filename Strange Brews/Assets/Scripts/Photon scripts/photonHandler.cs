using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// script for creating and joinging room, as well as instantiating player objects

public class photonHandler : MonoBehaviour
{

    public photonButtons photonB;

    public GameObject mainPlayer;

	private void Awake()
	{
		// won't destroy this object when the scene changes bc we will need it later
		DontDestroyOnLoad(this.transform);
		SceneManager.sceneLoaded += OnSceneFinishedLoading;
	}

    public void createNewRoom()
    {
        PhotonNetwork.CreateRoom(photonB.createRoomInput.text, new RoomOptions() { MaxPlayers = 2 }, null);
    }

    public void joinOrCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(photonB.joinRoomInput.text, roomOptions, TypedLobby.Default);

    }

    private void OnJoinedRoom()
    {
        moveScene();
        Debug.Log("We are connected to the room!");
    }

    public void moveScene()
    {
        PhotonNetwork.LoadLevel("MainMenu");
    }

    
    public void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {

		if (scene.name == "MainMenu")
		{
			SpawnPlayer();
			Debug.Log("loaded room");
		}
        

    }

	private void SpawnPlayer()
	{
		Debug.Log("spawn player");

		PhotonNetwork.Instantiate(mainPlayer.name, mainPlayer.transform.position, mainPlayer.transform.rotation, 0);

		if (PhotonNetwork.isMasterClient)
		{
			PhotonNetwork.playerName = "player1";
		}
		else
		{
			PhotonNetwork.playerName = "player2";
		}
	}



}

