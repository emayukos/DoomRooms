using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePainting : MonoBehaviour
{
<<<<<<< HEAD
    Vector3 originalPosition;

    Rigidbody2D rb;
=======
    private Vector3 originalPosition;

    private Rigidbody2D rb;
>>>>>>> e175e3eb8b7e096cd342cc78d17119bb3e30bfbb

    float currentTime;

    private void Start()
    {
        originalPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
<<<<<<< HEAD
=======
        movePaintUp();
        //stopPainting();

    }
    private void Update()
    {
        Vector3 stopPos = originalPosition + new Vector3(0, 5, 0);
        if (transform.position.y > stopPos.y ){
            rb.velocity = new Vector2(0, 0);
        }
>>>>>>> e175e3eb8b7e096cd342cc78d17119bb3e30bfbb
    }

    // when the button is pressed, move the painint up by applying velocity for a short period of time 
    public void movePaintUp() {
<<<<<<< HEAD
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(0, 2);
        currentTime = Time.time;
        while (Time.time != currentTime + 4) { continue; };

        rb.velocity = new Vector2(0, 0);
=======
        //rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(0, 2);
        currentTime = Time.time;
       
    }
    private void stopPainting() {
        StartCoroutine(Wait());
        //while (Time.time != currentTime + 4) { continue; };

        //rb.velocity = new Vector2(0, 0);
>>>>>>> e175e3eb8b7e096cd342cc78d17119bb3e30bfbb
    }

    // move the painting back to the original position 
    public void resetPainting()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        transform.position = originalPosition;
    }
<<<<<<< HEAD
=======

    IEnumerator Wait() {
        yield return new WaitForSeconds(2f);
    }
>>>>>>> e175e3eb8b7e096cd342cc78d17119bb3e30bfbb
}
