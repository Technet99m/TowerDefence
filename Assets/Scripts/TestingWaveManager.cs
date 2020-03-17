using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingWaveManager : MonoBehaviour
{
    [SerializeField] Text info;
    [SerializeField] InputField inp;
    float health = 1f;
    float totalDamage = 0;
    public void Init()
    {
        StartCoroutine(SpawnWave());
        WaveManager.EnemyKilled += OnEnemyDied;
    }
    IEnumerator SpawnWave()
    {
        
        float totalDamage = 0;
        for (int i = 0; i < i + 1; i++)
        { 
            GameObject enemy = EnemyPull.GetEnemy();
            enemy.GetComponent<EnemyDataHolder>().data = new EnemyData() {  shape = Shapes.Rectangle, health = health, speed = 1};
            enemy.GetComponent<EnemyHealth>().SetHealth();
            enemy.SetActive(true);
            enemy.GetComponent<SpriteRenderer>().color = ColorConverter.black;
            yield return new WaitForSeconds(3f);
        }
    }
    public void IncreaseHealth()
    {
        totalDamage = 0;
        health = float.Parse(inp.text);
        EnemyPull.Refresh();
    }
    void OnEnemyDied(object sender, EventArgs e)
    {
        totalDamage += health;
        info.text = totalDamage.ToString();
    }
}
