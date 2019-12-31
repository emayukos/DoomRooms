using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCameraFollow : MonoBehaviour
{
    public GameObject camera1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            //sets camera to follow spawned prefab of player so long as it's spawned in the collider range of the object this is attached to
            camera1.GetComponent<CameraFollowPrefab>().setPlayer(collision.gameObject);
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Destroy(gameObject);
        }
    }
}
