using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScreen : MonoBehaviour
{
    public GameObject computerScreenPanel;
    public GameObject openScreenPanel;

    //private bool isActive = true;

    private bool UIopen = false;
    private bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        computerScreenPanel.SetActive(false);
        openScreenPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (UIopen == false)
            {
                computerScreenPanel.SetActive(true);
                UIopen = !UIopen;
            }
            else
            {
                computerScreenPanel.SetActive(false);
                UIopen = !UIopen;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
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
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
            computerScreenPanel.SetActive(false);
            UIopen = !UIopen;

        }
    }

    [PunRPC]
    public void openComputer()
    {
        openScreenPanel.SetActive(true);
        computerScreenPanel.SetActive(false);
        computerScreenPanel = openScreenPanel;
    }
}
