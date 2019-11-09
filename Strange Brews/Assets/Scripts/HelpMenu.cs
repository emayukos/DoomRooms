using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    int onOff;
    GameObject child;

    void Awake()
    {
        onOff = 1;
    }

    private void Start()
    {
        child = GameObject.Find("Help Menu Panel");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            onOff = onOff * -1;
        }

        if(onOff < 0)
        {
            //turn off help menu
            child.SetActive(false);
        }
        if(onOff > 0)
        {
            //turn on help menu
            child.SetActive(true);
        }
    }

}
