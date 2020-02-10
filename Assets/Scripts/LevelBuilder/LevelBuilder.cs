using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public static LevelBuilder instance;
    [SerializeField] GameObject EnemyCell;
    public Transform EnemyContent, button;
    public WaveDataHolder selected;
    private void Awake()
    {
        instance = this;
    }
    public void AddCell()
    {
        Instantiate(EnemyCell, EnemyContent);
        button.SetAsLastSibling();
    }

    public void BuildWave()
    {
        int waveSize = 0;
        for (int i = 0; i < EnemyContent.childCount - 1; i++)
        {
            var cell = EnemyContent.GetChild(i).GetComponent<EnemyCellManager>();
            cell.GrabData();
            waveSize += cell.count;
        }
        WaveData tmp = new WaveData();
        tmp.enemies = new EnemyData[waveSize];
        print(waveSize);
        for (int i = 0, s = 0; i < waveSize;s++ )
        {
            var cell = EnemyContent.GetChild(s).GetComponent<EnemyCellManager>();
            for (int j = 0; j < cell.count; i++,j++)
                tmp.enemies[i] = cell.data;
        }
        selected.data = tmp;
    }
}
