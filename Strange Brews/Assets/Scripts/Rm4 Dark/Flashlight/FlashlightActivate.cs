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
        if (photonView.isMine)
        {
            flashlight.SetActive(true);
            hasFlashlight = true;
        }
        
    }

    public bool haveAFlashlight()
    {
        return hasFlashlight;
    }
}
