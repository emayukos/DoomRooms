using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePainting : Photon.MonoBehaviour
{
    private Vector3 startPosition;

    private Vector3 endPosition;

    private Rigidbody2D rb;

    private float distance = 30f;

    private float lerpTime = 5;

    private float currentLerpTime = 0;

    float currentTime;

    void movePaintUpRPC() {
        photonView.RPC("movePaintUp", PhotonTargets.All);
    }

    private void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + new Vector3(0f, 15f, 0f);
        rb = GetComponent<Rigidbody2D>();
        //stopPainting();
        //movePaintUp();
    }
    //private void Update()
    //{
    //Vector3 stopPos = originalPosition + new Vector3(0, 5, 0);
    //if (transform.position.y > stopPos.y ){
    //    rb.velocity = new Vector2(0, 0);
    //}
    //}

    // when the button is pressed, move the painint up by applying velocity for a short period of time 
    [PunRPC]
    public void movePaintUp() {
        //rb = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector3(0, 2, 0);
        transform.position = endPosition;

        /**
        rb.velocity = new Vector3(0, 2, 0);
        while (Vector3.Distance(transform.position, endPosition) > 1.0f)
        {
            continue;
        }
        rb.velocity = new Vector3(0, 0, 0);
        **/

        //}
        /**
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime >= lerpTime) {
            currentLerpTime = lerpTime;
        }
        float perc = currentLerpTime / lerpTime;
        transform.position = Vector3.Lerp(startPosition, endPosition, perc);
        **/

        //while (transform.position.y < (originalPosition.y + 10)){
         //   rb.velocity = new Vector3(0, 2, 0);
        //}
        //rb.velocity = new Vector3(0, 0, 0);

        //transform.Translate((Vector3.up*3) * Time.deltaTime);
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
        transform.position = startPosition;
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(2f);
    }
}
