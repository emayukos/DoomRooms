using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePainting : MonoBehaviour
{
    Vector3 originalPosition;

    Rigidbody2D rb;

    float currentTime;

    private void Start()
    {
        originalPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // when the button is pressed, move the painint up by applying velocity for a short period of time 
    public void movePaintUp() {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(0, 2);
        currentTime = Time.time;
        while (Time.time != currentTime + 4) { continue; };

        rb.velocity = new Vector2(0, 0);
    }

    // move the painting back to the original position 
    public void resetPainting()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        transform.position = originalPosition;
    }
}
