using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy", order = 52)]
public class EnemyData : ScriptableObject
{
    [SerializeField] float speed;
    [SerializeField] float health;
    [SerializeField] Colors color;
    [SerializeField] Shapes shape;
    public float Speed { get { return speed; } }
    public float Health { get { return health; } }
    public Colors Color { get { return color; } }
    public Shapes Shape { get { return shape; } }
}
