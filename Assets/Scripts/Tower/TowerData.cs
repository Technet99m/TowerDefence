using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerData : MonoBehaviour
{
    public float Range, Damage, Reload, BulletSpeed;
    public Effect Effect;
    public Shapes Shape;
    public bool smart;

    /*private void OnEnable()
    {
        Effect = new Effect();
        Effect.type = 0;
    }*/
}
[System.Serializable]
public class Effect
{
    public EffectType type;
    public int stage;
}

