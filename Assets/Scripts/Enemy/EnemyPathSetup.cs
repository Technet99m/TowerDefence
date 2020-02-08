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
        for (int i = 0; i < lr.positionCount; i++)
            EnemyPath.points[i] = lr.GetPosition(i);
    }
}
