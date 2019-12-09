using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPrefab : MonoBehaviour
{
    //attempt base for camera follow a prefab spawned mainPlayer in photon multiplayer format
    //modified from CameraFollow, credit for that script in CameraFollow comments

    GameObject player;                  //Public variable to store a reference to the player game object

    private Vector3 offset;             //Private variable to store the offset distance between the player and camera
    private bool playerSet = false;


    private void Update()
    {
        if (playerSet)
        {
            if (player != null)
            {
                //Calculate and store the offset value by getting the distance between the player's position and camera's position.
                offset = player.transform.position;
                offset.z -= 10.0f;
                offset = offset - player.transform.position;
                playerSet = true;
            }
        }
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }

    public void setPlayer(GameObject p)
    {
        player = p;
        playerSet = true;
    }
}
