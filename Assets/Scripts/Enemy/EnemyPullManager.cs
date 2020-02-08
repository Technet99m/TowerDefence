using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPullManager : MonoBehaviour
{
    static EnemyPullManager instance;

    [SerializeField] GameObject Enemy;

    [SerializeField] float lifeTime, reload;
    public static GameObject[] pull;
    static int index;
    private void Awake()
    {
        instance = this;
        RebuildPull(lifeTime, reload);
    }
    public static void RebuildPull(float lifeTime, float reload)
    {
        pull = new GameObject[(int)(lifeTime / reload) + 1];
        for (int i = 0; i < pull.Length; i++)
        {
            pull[i] = Instantiate(instance.Enemy, instance.transform);
            pull[i].SetActive(false);
        }
    }
    public static GameObject GetEnemy()
    {
        var tmp = pull[index];
        index++;
        if (index == pull.Length)
            index = 0;
        return tmp;
    }
}
