using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerData : MonoBehaviour
{
    [SerializeField ]float range, damage, reload, bulletSpeed;
    [SerializeField] Colors color;
    [SerializeField]  Shapes shape;
    public float Range { get { return range; } }
    public float Damage { get { return damage; } }
    public float Reload { get { return reload; } }
    public float BulletSpeed { get { return bulletSpeed; } }
    public Colors Color { get { return color; } }
    public Shapes Shape { get { return shape; } set { shape = value; } }

}
