using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightActivate : MonoBehaviour
{
    public GameObject flashlight;
    public PhotonView photonView;
    private bool hasFlashlight = false;

    // Start is called before the first frame update
    void Start()
    {
        flashlight.SetActive(false);
    }


    [PunRPC]
    public void activateFlashlight()
    {
        //used by flashlight standin
        if (photonView.isMine)
        {
            flashlight.SetActive(true);
            hasFlashlight = true;
        }
        
    }

    public bool haveAFlashlight()
    {
        //checks if player already has a flashlight so they don't steal both
        //used by flashlight standin
        return hasFlashlight;
    }
}
