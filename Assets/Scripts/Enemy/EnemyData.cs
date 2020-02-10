using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData 
{
    public float speed;
    public float health;
    public float money;
    public float damage;
    public Colors color;
    public Shapes shape;

    public bool Equals(EnemyData data)
    {
        if (speed == data.speed && health == data.health && money == data.money && damage == data.damage && color == data.color && shape == data.shape)
            return true;
        return false;
    }
}
