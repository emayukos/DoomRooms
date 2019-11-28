using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineMode : MonoBehaviour
{
    public bool offline;


    void Awake()
    {
        PhotonNetwork.offlineMode = offline;
    }

}
