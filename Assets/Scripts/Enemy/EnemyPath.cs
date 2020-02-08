using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath
{
    public static Vector3[] points;

    public static Vector3 GetNextPoint(int current)
    {
        if (current < points.Length - 1)
            return points[current + 1];
        else
            return points[points.Length - 1];
    }

    public static Vector3 GetFirstPoint()
    {
        return points[0];
    }
}
