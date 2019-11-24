using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projIntNew : MonoBehaviour
{
    public Sprite projoff;
    public Sprite projon;
    private bool inRange;
    private bool isOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (isOn)
            {
                turnProjectorOff();
            }
            else
            {
                turnProjectorOn();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
            Debug.Log("Recognised the player");
        }
        else
        {
            Debug.Log("OnTriggerEnter comaring tag isn't player");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
        else
        {
            Debug.Log("OnTriggerEnter comaring tag isn't player");
        }
    }

    void turnProjectorOn()
    {
        GetComponent<SpriteRenderer>().sprite = projon;
        isOn = true;

    }

    void turnProjectorOff()
    {
        GetComponent<SpriteRenderer>().sprite = projoff;
        isOn = false;

    }

}
