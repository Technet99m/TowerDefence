using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Wave", order = 51)]
public class WaveData : ScriptableObject
{
    [SerializeField] EnemyData[] enemies;
    public EnemyData[] Enemies { get { return enemies; } }
}
