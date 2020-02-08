using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            var enemy = EnemyPullManager.GetEnemy();
            enemy.SetActive(true);
            enemy.GetComponent<EnemyMovementComponent>().OnStartMoving();
        }
    }
}

    
   
