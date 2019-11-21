﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePainting : MonoBehaviour
{
    private Vector3 originalPosition;

    private Rigidbody2D rb;

    float currentTime;

    private void Start()
    {
        originalPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        movePaintUp();
        //stopPainting();

    }
    private void Update()
    {
        Vector3 stopPos = originalPosition + new Vector3(0, 5, 0);
        if (transform.position.y > stopPos.y ){
            rb.velocity = new Vector2(0, 0);
        }
    }

    // when the button is pressed, move the painint up by applying velocity for a short period of time 
    public void movePaintUp() {
        //rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(0, 2);
        currentTime = Time.time;
       
    }
    private void stopPainting() {
        StartCoroutine(Wait());
        //while (Time.time != currentTime + 4) { continue; };

        //rb.velocity = new Vector2(0, 0);
    }

    // move the painting back to the original position 
    public void resetPainting()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        transform.position = originalPosition;
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(2f);
    }
}