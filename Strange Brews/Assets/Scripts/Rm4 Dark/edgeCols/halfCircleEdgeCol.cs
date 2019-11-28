using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class halfCircleEdgeCol : MonoBehaviour
{
    //creates a half-circle collider upon game start of a radius specified in the inspector

    public int NumEdges;
    public float Radius;
    int halfpoint;

    // Use this for initialization
    void Start()
    {
        halfpoint = NumEdges / 2;

        EdgeCollider2D edgeCollider = GetComponent<EdgeCollider2D>();
        Vector2[] points = new Vector2[halfpoint];

        for (int i = 0; i < halfpoint; i++)
        {
            float angle = 2 * Mathf.PI * i / NumEdges;
            float x = Radius * Mathf.Cos(angle);
            float y = Radius * Mathf.Sin(angle);

            points[i] = new Vector2(x, y);
        }
        edgeCollider.points = points;
    }
}
