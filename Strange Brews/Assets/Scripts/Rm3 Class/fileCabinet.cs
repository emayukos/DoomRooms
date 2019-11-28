using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fileCabinet : MonoBehaviour
{

    public Sprite fileCabinetClosed;
    public Sprite fileCabinetOpen;
    public GameObject panelUI;
    public GameObject classRoomKey;


    public void Awake()
    {
        // set the key to be invisible when the game is rendered 
        classRoomKey.SetActive(false);
    }
    [PunRPC]
    private void openFileCabinet()
    {
        GetComponent<SpriteRenderer>().sprite = fileCabinetOpen;
        panelUI.SetActive(false);
        classRoomKey.SetActive(true);
    }

}
