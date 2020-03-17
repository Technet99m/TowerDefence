using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Enemy"))
        {
            WaveManager.EnemyKill();
            coll.gameObject.SetActive(false);
            PlayerHealth.instance.MinusHealth();
        }
    }
}
