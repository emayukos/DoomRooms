using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScreen : MonoBehaviour
{
    public GameObject computerScreenPanel;
    public GameObject openScreenPanel;
    public PhotonView photonView;

    private bool UIopen = false;
    private bool inRange = false;
    private bool unlocked = false;

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
                if (!unlocked)
                {
                    //password unlocking only for 1 player's screen
                    computerScreenPanel.SetActive(true);
                }
                else
                {
                    //Clue seen for both, both can try safe later
                    photonView.RPC("ComOn", PhotonTargets.All);
                }
                UIopen = !UIopen;
            }
            else
            {
                if (!unlocked)
                {
                    computerScreenPanel.SetActive(false);
                }
                else
                {
                    photonView.RPC("ComOff", PhotonTargets.All);
                }
                UIopen = !UIopen;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            inRange = false;
            if (!unlocked)
            {
                computerScreenPanel.SetActive(false);
            }
            else
            {
                photonView.RPC("ComOff", PhotonTargets.All);
            }
            UIopen = !UIopen;

        }
    }

    [PunRPC]
    public void openComputer()
    {
        openScreenPanel.SetActive(true);
        computerScreenPanel.SetActive(false);
        computerScreenPanel = openScreenPanel;
        unlocked = true;
    }

    [PunRPC]
    public void ComOn()
    {
        computerScreenPanel.SetActive(true);
    }

    [PunRPC]
    public void ComOff()
    {
        computerScreenPanel.SetActive(false);
    }
}
