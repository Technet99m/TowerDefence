using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBuilder : MonoBehaviour
{
    public static LevelBuilder instance;
    [SerializeField] GameObject EnemyCell,WaveCell, EnemiesSetup;
    public Transform EnemyContent,WaveContent, enemyAdd,waveAdd;
    public WaveDataHolder selected;

    private void Awake()
    {
        instance = this;
    }
    public void AddCell()
    {
        Instantiate(EnemyCell, EnemyContent);
        enemyAdd.SetAsLastSibling();
    }
    public void AddWave()
    {
        var label = Instantiate(WaveCell, WaveContent).transform.GetChild(0).GetComponentInChildren<Text>();
        waveAdd.SetAsLastSibling();
        label.text += label.transform.parent.parent.GetSiblingIndex().ToString();
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
        EnemiesSetup.SetActive(false);
        
    }

    public void SetupCells()
    {
        for (int i = 0; i < EnemyContent.childCount - 1; i++)
            Destroy(EnemyContent.GetChild(i).gameObject);
        EnemiesSetup.SetActive(true);
        if (selected == null)
            return;
        EnemyCellManager cell = null;
        for (int i = 0; i< selected.data.enemies.Length;i++)
        {

            if (i == 0 || !selected.data.enemies[i].Equals(selected.data.enemies[i - 1]))
            {
                cell = Instantiate(EnemyCell, EnemyContent).GetComponent<EnemyCellManager>();
                cell.Setup(selected.data.enemies[i]);
                enemyAdd.SetAsLastSibling();
            }
            else
            {
                cell.AddOne();
            }
        }
    }
}
