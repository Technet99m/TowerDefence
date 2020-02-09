using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy", order = 52)]
public class EnemyData : ScriptableObject
{
    [SerializeField] float speed;
    [SerializeField] float health;
    public float Speed { get { return speed; } }
    public float Health { get { return health; } }

}
