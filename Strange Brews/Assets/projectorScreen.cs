﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectorScreen : MonoBehaviour
{
    [SerializeField]
    GameObject projectorScreenPanel;

    //private bool isActive = true;

    private bool UIopen = false;
    private bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        projectorScreenPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (UIopen == false)
            {
                projectorScreenPanel.SetActive(true);
                UIopen = !UIopen;
            }
            else
            {
                projectorScreenPanel.SetActive(false);
                UIopen = !UIopen;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
            //if (collision.GetComponent<PhotonView>().isMine)
            //{
            //    inRange = true;
            //}

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
            projectorScreenPanel.SetActive(false);
            UIopen = !UIopen;

            //if (collision.GetComponent<PhotonView>().isMine)
            //{
            //    inRange = false;
            //    projectorScreenPanel.SetActive(false);
            //    UIopen = !UIopen;
            //}

        }
    }

}
