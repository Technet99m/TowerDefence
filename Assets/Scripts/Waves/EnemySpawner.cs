using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveData[] waves;
    [SerializeField] float timeBTweenWaves, timeBTweenEnemies;
    [SerializeField] Sprite[] sprites;
    [SerializeField] string levelID;
    void Start()
    {
        StartCoroutine(Spawn());
        var level = Resources.Load(levelID) as TextAsset;
        waves = JsonUtility.FromJson<LevelData>(level.text).waves.ToArray();
    }

    IEnumerator Spawn()
    {
        for(int i = 0;i < waves.Length;i++)
        {
            for(int j = 0;j<waves[i].enemies.Length;j++)
            {
                GameObject enemy = EnemyPull.GetEnemy();
                enemy.GetComponent<EnemyDataHolder>().data = waves[i].enemies[j];
                enemy.GetComponent<SpriteRenderer>().sprite = sprites[(int)waves[i].enemies[j].shape];
                enemy.GetComponent<SpriteRenderer>().color = ColorConverter.ToColor(waves[i].enemies[j].color);
                enemy.GetComponent<EnemyHealth>().SetHealth();
                enemy.SetActive(true);
                yield return new WaitForSeconds(timeBTweenEnemies);
            }
            yield return new WaitForSeconds(timeBTweenWaves);
        }
    }
}
