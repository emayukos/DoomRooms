using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class classList : MonoBehaviour
{
    [SerializeField]
    GameObject classListUI;

    private bool UIopen = false;
    private bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        classListUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // for single player testing
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (UIopen == false)
            {
                classListUI.SetActive(true);
                UIopen = !UIopen;
            }
            else
            {
                classListUI.SetActive(false);
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
            classListUI.SetActive(false);
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
