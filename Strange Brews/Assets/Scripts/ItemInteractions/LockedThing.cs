using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedThing : MonoBehaviour
{
    string lockedThingFound = null;
    bool unlock = false;
    GameObject inventory;


    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        if (lockedThingFound != null)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                //unlock
                unlock = inventory.GetComponent<Inventory>().searchItem(lockedThingFound);
                
                if(unlock == true)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("This needs a key.");
                }
                
            }
        }
    }


    void OnTriggerEnter2D(Collider2D col)   //col -> other thing was collided with, if attached to coin -> col = player
    {
        if (col.gameObject.CompareTag("Player"))
        {
            lockedThingFound = GetComponent<AssignedKey>().getKeyName();
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        lockedThingFound = null;

    }



}
