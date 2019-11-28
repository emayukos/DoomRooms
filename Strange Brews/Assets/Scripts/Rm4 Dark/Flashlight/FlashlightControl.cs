using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightControl : MonoBehaviour
{
    public GameObject flashlight1, flashlight2;



    private void activateFL1()
    {
        //flashlight1.GetComponent<FlashlightFollow>().activateLight();
    }

    private void activateFL2()
    {
        flashlight2.SetActive(true);
    }
}
