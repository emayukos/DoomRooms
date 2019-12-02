using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystalBallGroup : MonoBehaviour
{
    public crystalBall ball1, ball2;

    private bool connected;

    private void Update()
    {
        if (ball1.isItOpen() && ball2.isItOpen())
        {
            connected = true;
        }
        else
        {
            connected = false;
        }
    }

    public bool isConnected()
    {
        return connected;
    }
}
