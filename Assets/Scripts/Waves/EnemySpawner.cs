using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveData[] waves;
    [SerializeField] float timeBTweenWaves, timeBTweenEnemies;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for(int i = 0;i < waves.Length;i++)
        {
            for(int j = 0;j<waves[i].Enemies.Length;j++)
            {
                GameObject enemy = EnemyPull.GetEnemy();
                enemy.GetComponent<EnemyDataHolder>().data = waves[i].Enemies[j];
                enemy.SetActive(true);
                yield return new WaitForSeconds(timeBTweenEnemies);
            }
            yield return new WaitForSeconds(timeBTweenWaves);
        }
    }
}
