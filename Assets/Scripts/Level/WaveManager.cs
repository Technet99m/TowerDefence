﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveData wave;
    
    [SerializeField] float timeBTweenEnemies;
    [SerializeField] Sprite[] sprites;

    public static int waveSize;
    public static void EnemyKill()
    {
        waveSize--;
        if (waveSize == 0)
            EndWave();
    }
    public static void EndWave()
    {
        LevelManager.instance.NextWave();
    }
    public void StartWave()
    {
        waveSize = wave.enemies.Length;
        StartCoroutine(SpawnWave());
    }
    IEnumerator SpawnWave()
    {
        for (int i = 0; i < wave.enemies.Length; i++)
        {
            GameObject enemy = EnemyPull.GetEnemy();
            enemy.GetComponent<EnemyDataHolder>().data = wave.enemies[i];
            enemy.GetComponent<SpriteRenderer>().sprite = sprites[(int)wave.enemies[i].shape];
            enemy.GetComponent<SpriteRenderer>().color = ColorConverter.black;
            enemy.GetComponent<EnemyHealth>().SetHealth();
            enemy.SetActive(true);
            yield return new WaitForSeconds(timeBTweenEnemies);
        }
    }
}
