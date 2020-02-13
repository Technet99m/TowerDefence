using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAim : MonoBehaviour
{
    TowerData data;
    public Targeting aimType;
    [SerializeField] Transform target;
    [SerializeField] GameObject bull;
    public bool smart;
    private void Start()
    {
        data = GetComponent<TowerData>();
        InvokeRepeating(nameof(CheckForTarget), 1, 1 / 15f);
        StartCoroutine(Reload());
    }
    private void FixedUpdate()
    {
        LookAtTarget();
    }
    void LookAtTarget()
    {
        if (target)
        {
                transform.right = (target.position + target.GetComponent<EnemyMovementComponent>().direction * target.GetComponent<EnemyDataHolder>().data.speed *
                    Vector3.Distance(target.position, transform.GetChild(0).position) *(smart? 1f : 0.5f) / data.BulletSpeed) - transform.position;
        }
    }
    void CheckForTarget()
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, data.Range);
        List<Collider2D> list = new List<Collider2D>();
        foreach (Collider2D col in colls)
        {
            if(col.CompareTag("Enemy") && col.GetComponent<EnemyDataHolder>().data.shape == data.Shape && col.GetComponent<EnemyDataHolder>().data.color == data.Color)
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
        LookAtTarget();
    }

    IEnumerator Reload()
    {
        while(true)
        {
            if (target != null)
            {
                Shoot();
                yield return new WaitForSeconds(data.Reload);
            }
            else
                yield return null;
        }
    }
    void Shoot()
    {
        var bullet = Instantiate(bull,transform.GetChild(0).position,Quaternion.identity, transform).GetComponent<BulletController>();
        bullet.Initialize(data.Damage, data.BulletSpeed, data.Shape,data.Color);
    }
}


