using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    EnemyDataHolder dataHolder;
    public float health;

    private void Start()
    {
        dataHolder = GetComponent<EnemyDataHolder>();
    }

    private void OnEnable()
    {
        if(dataHolder!=null)
            health = dataHolder.data.Health;
    }
}
