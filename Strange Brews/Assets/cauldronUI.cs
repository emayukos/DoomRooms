﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cauldronUI : MonoBehaviour
{
    public PhotonView photonView;

    private bool code1 = true, code2 = true, code3 = true;


    public Toggle item1, item2, item3;
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

    public void pressMix()
    {
        if (item1.isOn == code1 && item2.isOn == code2 && item3.isOn == code3)
        {
            photonView.RPC("brewPotion", PhotonTargets.All);
        }
        
    }

    [PunRPC]
    public void brewPotion()
    {
        key.SetActive(true);
        cauldronpanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(collision.GetComponent<PhotonView>().isMine)
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
