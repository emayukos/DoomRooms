using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public PhotonView photonView;
    public GameObject endDoor;
    private bool[] switches = new bool[2];


    // Start is called before the first frame update
    void Start()
    {
        switches[0] = false;
        switches[1] = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Switch 0: " + switches[0] + "   Switch 1: " + switches[1]);
        if(switches[0] && switches[1])
        {
            //endDoor.GetComponent<SwitchDoor>().doorOpen();
            endDoor.GetComponent<SwitchDoor>().photonView.RPC("doorOpen", PhotonTargets.All);
        }
    }

    [PunRPC]
    public void setSwitchOn(int s)
    {
        if(s == 1 || s == 0)
        {
            switches[s] = true;
        }
        
    }

    [PunRPC]
    public void setSwitchOff(int s)
    {
        if (s == 1 || s == 0)
        {
            switches[s] = false;
        }
        
    }

}
