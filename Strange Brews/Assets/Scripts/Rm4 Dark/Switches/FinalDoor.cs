using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    //End door controller of Dark Room, opened by two buttons held simultaneously
    //not on actual door gameObject

    public PhotonView photonView;   //door's photonview
    public GameObject endDoor;      //door's gameObject
    private bool[] switches = new bool[2];


 
    void Start()
    {
        switches[0] = false;
        switches[1] = false;
    }


    void Update()
    {
        //Debug.Log("Switch 0: " + switches[0] + "   Switch 1: " + switches[1]);
        if(switches[0] && switches[1])
        {
            //endDoor.GetComponent<SwitchDoor>().doorOpen();    //for offline initial testing
            endDoor.GetComponent<SwitchDoor>().photonView.RPC("doorOpen", PhotonTargets.All);
        }
    }

    [PunRPC]
    public void setSwitchOn(int s)
    {
        if(s == 1 || s == 0)    //avoid array out of bounds error
        {
            switches[s] = true;
        }
        
    }

    [PunRPC]
    public void setSwitchOff(int s)
    {
        if (s == 1 || s == 0)    //avoid array out of bounds error
        {
            switches[s] = false;
        }
        
    }

}
