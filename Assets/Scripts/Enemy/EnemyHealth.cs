using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    EnemyDataHolder dataHolder;
    public float health;

    public void SetHealth()
    {
        if(dataHolder==null)
            dataHolder = GetComponent<EnemyDataHolder>();
        health = dataHolder.data.health;
    }
    public void GetDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }
    private void Die()
    {
        WaveManager.EnemyKill();
        SetHealth();
        Debug.Log("Died " + gameObject.name);
        gameObject.SetActive(false);
    }
}
