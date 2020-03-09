using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementComponent : MonoBehaviour
{
    Vector3 target;
    EnemyDataHolder dataHolder;
    public Vector3 direction
    { 
        get {
            return (target - transform.position).normalized;
        } 
    }
    int currentPoint;
    public float distance;

    private void Awake()
    {
        dataHolder = GetComponent<EnemyDataHolder>();
    }
    private void OnEnable()
    {
        if (EnemyPath.points == null)
            return;
        transform.position = EnemyPath.GetFirstPoint();
        target = EnemyPath.GetNextPoint(0);
        currentPoint = 1;
        GetComponent<SpriteRenderer>().color = Color.black;
    }

    private void Update()
    {
        float diff;
        Vector3 tmp = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, dataHolder.data.speed * Time.deltaTime);
        diff = Vector3.Distance(tmp, transform.position);
        distance += diff;
        transform.right = direction;
        if (diff < float.Epsilon)
        {
            target = EnemyPath.GetNextPoint(currentPoint);
            currentPoint++;
        }
    }
}
