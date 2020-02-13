using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveData wave;
    [SerializeField] float timeBTweenEnemies;
    [SerializeField] Sprite[] sprites;


    IEnumerator SpawnWave(WaveData wave)
    {
        for (int j = 0; j < wave.enemies.Length; j++)
        {
            GameObject enemy = EnemyPull.GetEnemy();
            enemy.GetComponent<EnemyDataHolder>().data = wave.enemies[j];
            enemy.GetComponent<SpriteRenderer>().sprite = sprites[(int)wave.enemies[j].shape];
            enemy.GetComponent<SpriteRenderer>().color = ColorConverter.ToColor(wave.enemies[j].color);
            enemy.GetComponent<EnemyHealth>().SetHealth();
            enemy.SetActive(true);
            yield return new WaitForSeconds(timeBTweenEnemies);
        }
    }
}
