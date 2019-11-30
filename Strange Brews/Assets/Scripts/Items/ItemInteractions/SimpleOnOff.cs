using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleOnOff : MonoBehaviour
{
    private bool inRange = false;
    private bool On = false;
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj.SetActive(false);
    }

    private void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (On)
            {
                obj.SetActive(false);
                On = false;
            }
            else
            {
                obj.SetActive(true);
                On = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
            if (On)
            {
                obj.SetActive(false);
                On = false;
            }
        }
    }
}
