using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class EnemyPathSetup : MonoBehaviour
{
    private void Awake()
    {
        var lr = GetComponent<LineRenderer>();
        EnemyPath.points = new Vector3[lr.positionCount];
        EdgeCollider2D edge = GetComponent<EdgeCollider2D>();
        Vector2[] edgePoints = new Vector2[lr.positionCount];
        for (int i = 0; i < lr.positionCount; i++)
        {
            EnemyPath.points[i] = lr.GetPosition(i);
            edgePoints[i] = lr.GetPosition(i);
        }
        edge.points = edgePoints;
        
    }
}
