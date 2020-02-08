using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementComponent : MonoBehaviour
{
    Vector3 target;

    public Vector3 direction
    { 
        get {
            return (target - transform.position).normalized;
        } 
    }
    public float speed;
    int currentPoint;

    public void OnStartMoving()
    {
        transform.position = EnemyPath.GetFirstPoint();
        target = EnemyPath.GetNextPoint(0);
        currentPoint = 1;
    }

    void Update()
    {
        float diff;
        Vector3 tmp = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        diff = Vector3.Distance(tmp, transform.position);
        if (diff < float.Epsilon)
        {
            target = EnemyPath.GetNextPoint(currentPoint);
            currentPoint++;
        }
    }
}
