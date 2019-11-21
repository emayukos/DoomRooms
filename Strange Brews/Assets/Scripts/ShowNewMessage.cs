using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNewMessage : MonoBehaviour
{
    bool haveNewMessage = false;
    public GameObject messageBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (haveNewMessage)
        {
            messageBox.SetActive(true);
        }
    }


    public void setHaveNewMessage()
    {
        haveNewMessage = true;
    }
}
