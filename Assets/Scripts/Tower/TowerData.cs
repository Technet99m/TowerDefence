using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTower", menuName = "Tower", order = 53)]
public class TowerData : ScriptableObject
{
    [SerializeField] float range, damage, reload;
    [SerializeField] Colors color;
    [SerializeField] Shapes shape;
    [SerializeField] Sprite sprite;


    public float Range { get { return range; } }
    public float Damage { get { return damage; } }
    public float Reload { get { return reload; } }
    public Colors Color { get { return color; } }
    public Shapes Shape { get { return shape; } }
    public Sprite Sprite { get { return sprite; } }
}
