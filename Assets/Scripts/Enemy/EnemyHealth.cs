using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    EnemyDataHolder dataHolder;
    public float health;

    private void Start()
    {
        dataHolder = GetComponent<EnemyDataHolder>();
    }
    private void OnEnable()
    {
        if(dataHolder!=null)
            health = dataHolder.data.Health;
    }
    public void GetDamage(float damage)
    {
        health -= damage;
        if (health < 0)
            Die();
    }
    void Die()
    {

    }
}
