using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleEdgeCollider : MonoBehaviour
{
    //creates a circular collider upon game start of a radius specified in the inspector
    //currently, circle does not fully close, there is an opening before the start point, size dependent on NumEdges
    //CREDIT TO: Talonj123 from https://answers.unity.com/questions/612222/inverted-2d-circle-collider.html

    public int NumEdges;
    public float Radius;

    // Use this for initialization
    void Start()
    {
        EdgeCollider2D edgeCollider = GetComponent<EdgeCollider2D>();
        Vector2[] points = new Vector2[NumEdges];

        for (int i = 0; i < NumEdges; i++)
        {
            float angle = 2 * Mathf.PI * i / NumEdges;
            float x = Radius * Mathf.Cos(angle);
            float y = Radius * Mathf.Sin(angle);

            points[i] = new Vector2(x, y);
        }
        edgeCollider.points = points;
    }
}
