using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineMode : MonoBehaviour
{
    //for easy toggle on/off to offline state for single player testing of some parts of the Dark Room level
    public bool offline;


    void Awake()
    {
        PhotonNetwork.offlineMode = offline;
    }

}
