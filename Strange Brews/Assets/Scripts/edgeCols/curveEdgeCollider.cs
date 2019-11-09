using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curveEdgeCollider : MonoBehaviour
{

    public int NumEdges;
    public float Radius;
    public float inputAngle;
    public float rotation;

    private int anglepoint;
    private int diameterAngle;
    private float curRotation = 0.0f;
    

    // Use this for initialization
    void Start()
    {
        //(int)Math.Round(precise, 0);
        diameterAngle = Mathf.RoundToInt(360.0f / inputAngle);

        anglepoint = NumEdges / diameterAngle;

        EdgeCollider2D edgeCollider = GetComponent<EdgeCollider2D>();
        Vector2[] points = new Vector2[anglepoint];

        for (int i = 0; i < anglepoint; i++)
        {
            float angle = 2 * Mathf.PI * i / NumEdges;
            float x = Radius * Mathf.Cos(angle);
            float y = Radius * Mathf.Sin(angle);

            points[i] = new Vector2(x, y);
        }
        edgeCollider.points = points;
    }

    private void Update()
    {
        //rotate collider to desired position

        //Vector3 angle = transform.localEulerAngles;
        //angle.z = Mathf.Clamp(angle.z + Time.deltaTime * rotateRate, 0.0f, 60.0f);
        //rotater  = Mathf.Clamp(rbody.rotation + frotateBy, lowBound, highBound);
        //rotator = rbody.rotation;
        //parent.localEulerAngles = angle;

        //parent.Rotate(rotateBy, Time.deltaTime * rotateRate);

        if (curRotation != rotation)
        {
            transform.Rotate(0.0f, 0.0f, rotation, Space.Self);
            transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
            curRotation = rotation;
        }

    }

}
