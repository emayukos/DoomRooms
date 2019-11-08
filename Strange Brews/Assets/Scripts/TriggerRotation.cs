using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRotation : MonoBehaviour
{
    private Transform parent;
    private int rotate = 0;
    private Vector3 rotateBy;
    private float frotateBy;
    private float highBound, lowBound;
    private Rigidbody2D rbody;
    float rotateRate = 50.0f;
    private bool inBounds;
    private float rotator;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        rbody = parent.gameObject.GetComponent<Rigidbody2D>();

        if (parent.gameObject.name == "Mid Spinner")
        {
            highBound = 0.0f;
            lowBound = -90.0f;
        }

        if (parent.gameObject.name == "End Spinner")
        {
            highBound = 60.0f;
            lowBound = -60.0f;
        }
    }

    private void Update()
    {

        //Vector3 angle = parent.localEulerAngles;
        //angle.z = Mathf.Clamp(angle.z + Time.deltaTime * rotateRate, 0.0f, 60.0f);
        //rotater  = Mathf.Clamp(rbody.rotation + frotateBy, lowBound, highBound);
        rotator = rbody.rotation;
        //parent.localEulerAngles = angle;

        inBounds = rbody.rotation <= highBound && rbody.rotation >= lowBound;
        

        if (rotate != 0)
        {
            //parent.Rotate(rotateBy, Time.deltaTime * rotateRate);
            rbody.MoveRotation(Mathf.Clamp(rbody.rotation + frotateBy, lowBound, highBound));
            Debug.Log("clamp value: " + Mathf.Clamp(rotator + frotateBy, lowBound, highBound));
            Debug.Log(rbody.rotation);
            Debug.Log(inBounds + " " + lowBound);
            if (inBounds)
            {
                
                //parent.Rotate(rotateBy, Time.deltaTime * rotateRate);
                Debug.Log(rbody.rotation);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rotate = 1;
        }
        
        //get parent
        //transform parent rotation z=
        // clockwise   => -
        // c.clockwise => +

        if (gameObject.tag == "clockwise spin")
        {
            //transform parent rotation z= -#
            //rotateBy = Vector3.back;
            frotateBy = -1.0f;
            
        }

        if (gameObject.tag == "c.clockwise spin")
        {
            //transform parent rotation z= +#
            //rotateBy = Vector3.forward;
            frotateBy = 1.0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        rotate = 0;
    }
}
