using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPull : MonoBehaviour
{
    [SerializeField] int capacity;
    [SerializeField] GameObject Enemy;
    static GameObject[] pull;

    static int index;
    static int size;
    private void Awake()
    {
        pull = new GameObject[capacity];
        index = 0;
        size = capacity;
        for(int i = 0;i<capacity;i++)
        {
            pull[i] = Instantiate(Enemy, transform);
            pull[i].SetActive(false);
        }
    }

    public static GameObject GetEnemy()
    {
        var tmp = pull[index];
        index = (index + 1) % size;
        return tmp;
    }
    public static void Refresh()
    {
        foreach (var g in pull)
            g.SetActive(false);
        index = 0;
    }
}
