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
        int waveSize = Random.Range(minWaveSize, minWaveSize + wave);
        newWave.enemies = new EnemyData[waveSize];
        switch (wave)
        {
            #region HardCodedWaves
            case 1:
                for (int i = 0; i < waveSize; i++)
                    newWave.enemies[i] = new EnemyData() { health = 5, shape = Shapes.Rectangle, speed = 2 };
                break;
            case 2:
                for (int i = 0; i < waveSize; i++)
                    newWave.enemies[i] = new EnemyData() { health = 7, shape = Shapes.Rectangle, speed = 2 };
                break;
            case 3:
                for (int i = 0; i < waveSize; i++)
                {
                    if (i < waveSize / 2)
                        newWave.enemies[i] = new EnemyData() { health = 7, shape = Shapes.Rectangle, speed = 2 };
                    else
                        newWave.enemies[i] = new EnemyData() { health = 5, shape = Shapes.Circle, speed = 2 };
                }
                break;
            case 4:
                for (int i = 0; i < waveSize; i++)
                    newWave.enemies[i] = new EnemyData() { health = 7, shape = Shapes.Circle, speed = 2 };
                break;
            case 5:
                for (int i = 0; i < waveSize; i++)
                {
                    if (i < waveSize / 2)
                        newWave.enemies[i] = new EnemyData() { health = 10, shape = Shapes.Rectangle, speed = 3 };
                    else
                        newWave.enemies[i] = new EnemyData() { health = 7, shape = Shapes.Triangle, speed = 2 };
                }
                break;
            case 6:
                for (int i = 0; i < waveSize; i++)
                {
                    if (i < waveSize / 3)
                        newWave.enemies[i] = new EnemyData() { health = 12, shape = Shapes.Circle, speed = 2.5f };
                    else if(i< waveSize * 2/3f)
                        newWave.enemies[i] = new EnemyData() { health = 7, shape = Shapes.Triangle, speed = 2 };
                    else
                        newWave.enemies[i] = new EnemyData() { health = 10, shape = Shapes.Rectangle, speed = 2 };
                }
                break;
            case 7:
                for (int i = 0; i < waveSize; i++)
                    newWave.enemies[i] = new EnemyData() { health = 7, shape = Shapes.Hexagon, speed = 2.5f };
                break;
            #endregion
            default:

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
