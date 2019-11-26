using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curveEdgeCollider : MonoBehaviour
{
    //creates a circular collider upon game start of an approximate angle and a radius specified in the inspector
    // --- angle width has limitations to how specifically it can be sized, rounds down to nearest point due to process at **
    //can then be rotated by -180 < degrees <= 180, to the degree given in the inspector for the 'rotation' variable

    public int NumEdges;
    public float Radius;
    public float inputAngle;
    public float rotation;

    private int anglepoint;
    private int diameterAngle;
    private float curRotation = 0.0f;
    

    void Start()
    {
        // **
        diameterAngle = Mathf.RoundToInt(360.0f / inputAngle);
        anglepoint = NumEdges / diameterAngle;
        // **

        EdgeCollider2D edgeCollider = GetComponent<EdgeCollider2D>();
        Vector2[] points = new Vector2[anglepoint];

        // ** anglepoint must be an int due to 'for' loop creation mechanism
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
        if (curRotation != rotation)
        {
            transform.Rotate(0.0f, 0.0f, rotation, Space.Self);
            transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
            curRotation = rotation;
        }
    }

}
