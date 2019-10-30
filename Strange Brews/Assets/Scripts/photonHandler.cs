using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class photonHandler : MonoBehaviour
{

    public photonButtons photonB;

    public GameObject mainPlayer;


    private void Awake()
    {
        // won't destroy this object when the scene changes bc we will need it later
        DontDestroyOnLoad(this.transform);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void createNewRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(photonB.createRoomInput.text, roomOptions, null);
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

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "MainMenu")
        {
            SpawnPlayer();
            Debug.Log("loaded room");
        }
    }

   

    private void SpawnPlayer()
    {
        Debug.Log("spawn player");
        PhotonNetwork.Instantiate(mainPlayer.name, mainPlayer.transform.position, mainPlayer.transform.rotation, 0);
    }


    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }



}

