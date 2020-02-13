using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int wave;
    public static int stage;
    [SerializeField] int minWaveSize;

    void Start()
    {
        wave = 0;
        NextWave();
    }
    void NextWave()
    {
        wave++;
        CheckStage();
        WaveData newWave = new WaveData();
        int waveSize = Random.Range(minWaveSize, minWaveSize + wave + 1);
        newWave.enemies = new EnemyData[waveSize];
        switch (wave)
        {
            #region HardCodedWaves
            case 1:
                for (int i = 0; i < waveSize; i++)
                    newWave.enemies[i] = new EnemyData() { health = 5, shape = Shapes.Rectangle, speed = 1 };
                break;
            case 2:
                for (int i = 0; i < waveSize; i++)
                    newWave.enemies[i] = new EnemyData() { health = 7, shape = Shapes.Rectangle, speed = 1 };
                break;
            case 3:
                for (int i = 0; i < waveSize; i++)
                {
                    if (i < waveSize / 2)
                        newWave.enemies[i] = new EnemyData() { health = 7, shape = Shapes.Rectangle, speed = 1 };
                    else
                        newWave.enemies[i] = new EnemyData() { health = 5, shape = Shapes.Circle, speed = 1 };
                }
                break;
            case 4:
                for (int i = 0; i < waveSize; i++)
                    newWave.enemies[i] = new EnemyData() { health = 7, shape = Shapes.Circle, speed = 1 };
                break;
            case 5:
                for (int i = 0; i < waveSize; i++)
                {
                    if (i < waveSize / 2)
                        newWave.enemies[i] = new EnemyData() { health = 10, shape = Shapes.Rectangle, speed = 2 };
                    else
                        newWave.enemies[i] = new EnemyData() { health = 7, shape = Shapes.Triangle, speed = 1 };
                }
                break;
            case 6:
                for (int i = 0; i < waveSize; i++)
                {
                    if (i < waveSize / 3)
                        newWave.enemies[i] = new EnemyData() { health = 12, shape = Shapes.Circle, speed = 1.5f };
                    else if(i< waveSize * 2/3f)
                        newWave.enemies[i] = new EnemyData() { health = 7, shape = Shapes.Triangle, speed = 1 };
                    else
                        newWave.enemies[i] = new EnemyData() { health = 10, shape = Shapes.Rectangle, speed = 1 };
                }
                break;
            case 7:
                for (int i = 0; i < waveSize; i++)
                    newWave.enemies[i] = new EnemyData() { health = 7, shape = Shapes.Hexagon, speed = 1f };
                break;
            #endregion
            default:
                int types = Random.Range(2, wave / 3);
                int[] counts = new int[types];
                int maxSize = waveSize;
                for (int i = 0; i < types; i++)
                {
                    if(i==types-1)
                    {
                        counts[i] = maxSize;
                        break;
                    }
                    int tmp = Random.Range(1, maxSize / 2);
                    counts[i] = tmp;
                    maxSize -= tmp;
                }
                print(types);
                List<EnemyData> enemies = new List<EnemyData>();
                for(int i = 0;i<types;i++)
                {
                    EnemyData tmp = new EnemyData()
                    {
                        health = Random.value * wave / 10 + wave,
                        speed = (2 + Random.value / 0.5f) + (Random.value > 0.5f+(1/(wave+1f)) ? 0.2f : -1),
                        shape = (Shapes)Random.Range(0, 4)
                    };
                    print(tmp.speed);
                    enemies.Add(tmp);
                }
                enemies.Sort((x, y) => y.speed.CompareTo(x.speed));
                for(int i = 0, k = 0;i<types;i++)
                {
                    for (int j = 0; j < counts[i]; j++, k++)
                        newWave.enemies[k] = enemies[i];
                }
                break;
        }
        WaveManager.wave = newWave;
    }

    void CheckStage()
    {
        if (wave == 10 || wave == 30 || wave == 70 || wave == 150)
        {
            stage++;
            CameraController.instance.UpdateCameraBorders(stage);
        }
    }
}
