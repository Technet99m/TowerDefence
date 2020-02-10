using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public static LevelBuilder instance;
    [SerializeField] GameObject EnemyCell;
    public Transform content, button;
    private void Awake()
    {
        instance = this;
    }
    public void AddCell()
    {
        Instantiate(EnemyCell, content);
        button.SetAsLastSibling();
    }
}
