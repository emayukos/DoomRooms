using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safe : MonoBehaviour
{
    [SerializeField]
    GameObject codePanel, closedSafe, openedSafe;

    public bool isSafeOpened = false; // should not initially be open

    private bool UIopen = false;

    private bool isIn = false;

    public string code = "3101";


    // Start is called before the first frame update
    void Start()
    {
        codePanel.SetActive(false);
        closedSafe.SetActive(true);
        openedSafe.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isIn && Input.GetKeyDown("e") && !isSafeOpened)
        {
            Debug.Log("pressed e");
            if (UIopen == false)
            {
                codePanel.SetActive(true);
                UIopen = !UIopen;
            }
            else
            {
                codePanel.SetActive(false);
                UIopen = !UIopen;

            }
        }
    }

    // used to update the safe state
    void openSafe()
    {
        codePanel.SetActive(false);
        closedSafe.SetActive(false);
        openedSafe.SetActive(true);
        isSafeOpened = true;
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("mainPlayer(Clone)") && !isSafeOpened)
        {
            codePanel.SetActive(true); // open the code panel
        }

    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("mainPlayer(Clone)"))
        {
            isIn = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name.Equals("mainPlayer(Clone)"))
        {
            isIn = false;
            codePanel.SetActive(false);
            UIopen = !UIopen;
        }
    }


}
