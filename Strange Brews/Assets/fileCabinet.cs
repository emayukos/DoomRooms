using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fileCabinet : MonoBehaviour
{

    public Sprite fileCabinetClosed;
    public Sprite fileCabinetOpen;
    public GameObject panelUI;

    [PunRPC]
    private void openFileCabinet()
    {
        GetComponent<SpriteRenderer>().sprite = fileCabinetOpen;
        panelUI.SetActive(false);
    }

}
