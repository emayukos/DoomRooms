using UnityEngine;
using System.Collections;
 
public class NetworkManager : MonoBehaviour {
 
    public string roomName = "MainMenu";
 
    public static bool IsConnected
    {
        get
        {
            return PhotonNetwork.offlineMode == false && PhotonNetwork.connectionState == ConnectionState.Connected;
        }
    }
 
 
    void Start ()
    {
        DontDestroyOnLoad( gameObject );
    }
 
    public void Connect()
    {
        if( PhotonNetwork.connectionState != ConnectionState.Disconnected )
        {
            return;
        }
       
        try
        {
            PhotonNetwork.ConnectUsingSettings( "1.0" );
            PhotonNetwork.autoJoinLobby = true;
        }
        catch
        {
            Debug.LogWarning( "Couldn't connect to server" );
        }
    }
 
    void OnJoinedLobby ()
    {
        RoomOptions roomOptions = new RoomOptions () { isVisible = true, maxPlayers = 2 };
        PhotonNetwork.JoinOrCreateRoom (roomName, roomOptions, TypedLobby.Default);
        Debug.Log ("OnJoinedLobby");
    }
 
    void OnJoinedRoom ()
    {
        Application.LoadLevel ("Room");
        Debug.Log ("OnJoinedRoom");
    }
 
}