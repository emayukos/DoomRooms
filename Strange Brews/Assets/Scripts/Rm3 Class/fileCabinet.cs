using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fileCabinet : MonoBehaviour
{

    public Sprite fileCabinetClosed;
    public GameObject fileCabinetOpen;
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
        GetComponent<SpriteRenderer>().sprite = fileCabinetOpen.GetComponent<SpriteRenderer>().sprite;
        transform.localScale = fileCabinetOpen.transform.localScale;
        transform.position = fileCabinetOpen.transform.position;
        panelUI.SetActive(false);
        classRoomKey.SetActive(true);
    }

}
