using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingInteraction : Photon.MonoBehaviour
{
    //upon button pres, move the painting up. Right now there is no animation 
    //associated with the painting moving up, but right now it just will teleport up


	void movePaintingRPC()
	{
		photonView.RPC( "movePainting", PhotonTargets.All);
	}
	
	[PunRPC]
    public void movePainting() {
        // when button is pressed
        transform.position = transform.position + new Vector3(0, 5, 0);
		//Destroy(gameObject);
         
    }
}
