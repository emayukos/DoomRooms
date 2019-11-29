using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cauldron : MonoBehaviour
{

    public GameObject potion1, potion2, cauldronpanel;
    private bool inRange, isOpen;
	public bool potionMade; // made public for testing


    // Start is called before the first frame update
    void Start()
    {
        cauldronpanel.SetActive(false);
        // commented out for testing
        //potion1.SetActive(false);
		//potion2.SetActive(false);
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
    	potion1.SetActive(true);
		potion2.SetActive(true);
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
