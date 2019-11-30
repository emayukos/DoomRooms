using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCameraFollow : MonoBehaviour
{
    public GameObject camera1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            camera1.GetComponent<CameraFollowPrefab>().setPlayer(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
