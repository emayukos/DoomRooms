using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photonConnect : MonoBehaviour
{
    public string versionName = "0.1";

	public GameObject sectionView1, sectionView2, sectionView3;
    
    // this function connnects to the photon network 
    private void Awake(){
        PhotonNetwork.ConnectUsingSettings(versionName);
        Debug.Log("Connecting to photon...");
        
    }
    
    // this is a premade function in the photon plugin, ths function tells us that we are joined to the photon server  
    private void OnConnectedToMaster(){
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("We are connected to master");
    }
    
    
    // another premade function in photon, tells us when the players have joined their lobby
   	private void OnJoinedLobby(){
   		sectionView1.SetActive(false);
   		sectionView2.SetActive(true);
   		
   		Debug.Log("On Joined Lobby");
   	}

    // When one of the user's loses connection to the photon conection
	[System.Obsolete]
	private void OnDisconnectedFromPhoton(){
   		if(sectionView1.active)
   			sectionView1.SetActive(false);
   		if(sectionView2.active)
   			sectionView2.SetActive(false);
   		
   		sectionView3.GetActive();
	}
}
