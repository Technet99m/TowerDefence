using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveData wave;
    
    [SerializeField] float timeBTweenEnemies;
    [SerializeField] Sprite[] sprites;

    public static int waveSize;
    IEnumerator SpawnWave()
    {
        for (int i = 0; i < wave.enemies.Length; i++)
        {
            GameObject enemy = EnemyPull.GetEnemy();
            enemy.GetComponent<EnemyDataHolder>().data = wave.enemies[i];
            enemy.GetComponent<SpriteRenderer>().sprite = sprites[(int)wave.enemies[i].shape];
            enemy.GetComponent<EnemyHealth>().SetHealth();
            enemy.SetActive(true);
            yield return new WaitForSeconds(timeBTweenEnemies);
        }
    }

    public void StartWave()
    {
        StartCoroutine(SpawnWave());
    }
    void EndWave()
    {

    }
}
