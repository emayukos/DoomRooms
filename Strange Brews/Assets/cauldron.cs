using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cauldron : MonoBehaviour
{

    public GameObject key, cauldronpanel;
    private bool inRange, isOpen, potionMade;


    // Start is called before the first frame update
    void Start()
    {
        cauldronpanel.SetActive(false);
        key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E) && !potionMade)
        {
            isOpen = !isOpen;
            cauldronpanel.SetActive(isOpen);

        }
    }

    [PunRPC]
    public void brewPotion()
    {
        key.SetActive(true);
        cauldronpanel.SetActive(false);
        potionMade = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PhotonView>().isMine)
            {
                inRange = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PhotonView>().isMine)
            {
                inRange = false;
            }
        }
    }
}
