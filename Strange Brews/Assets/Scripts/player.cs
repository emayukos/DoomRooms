using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Collider thisObjectCollider;


    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        // dont want objects to collide w/ floor/ceiling!

        // Display what we hit
        string hitObject = collisionInfo.collider.tag; // get the tag of the object we hit
        if (hitObject == "Key")
        {
            Debug.Log("Player got key");
            thisObjectCollider = GetComponent<thisObjectCollider>();
            thisObjectCollider.isTrigger = true; // make player a trigger for the door >> must reset this when going to new scene
            Debig.Log(" Player is trigger.")
        }
        }
    }
}
