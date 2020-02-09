using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAim : MonoBehaviour
{
    public Targeting aimType;
    TowerDataHolder dataHolder;
    [SerializeField] Transform target;
    public bool smart;
    private void Start()
    {
        dataHolder = GetComponent<TowerDataHolder>();
        InvokeRepeating(nameof(CheckForTarget), 1, 1 / 15f);
    }
    private void FixedUpdate()
    {
        if (target)
        {
            if (smart)
                transform.right = ;
            else
                transform.right = target.position - transform.position;
        }
            
        else
            transform.right = Vector3.right;
    }

    void CheckForTarget()
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, dataHolder.data.Range);
        List<Collider2D> list = new List<Collider2D>();
        foreach (Collider2D col in colls)
        {
            if(col.CompareTag("Enemy"))
                list.Add(col);
        }
        if (list.Count == 0)
        {
            target = null;
            return;
        }
        switch (aimType)
        {
            case Targeting.Weakest:
                list.Sort((x, y) => x.GetComponent<EnemyHealth>().health.CompareTo(y.GetComponent<EnemyHealth>().health));
                target = list[0].transform;
                break;
            case Targeting.Strongest:
                list.Sort((x, y) => y.GetComponent<EnemyHealth>().health.CompareTo(x.GetComponent<EnemyHealth>().health));
                target = list[0].transform;
                break;
            case Targeting.Nearest:
                list.Sort((x, y) => y.GetComponent<EnemyMovementComponent>().distance.CompareTo(x.GetComponent<EnemyMovementComponent>().distance));
                target = list[0].transform;
                break;
        }        
    }
}

public enum Targeting
{
    Weakest,
    Strongest,
    Nearest
}
