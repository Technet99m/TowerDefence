using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerData : MonoBehaviour
{
    public float Range, Damage, Reload, BulletSpeed;
    public Effect Effect;
    public Shapes Shape;
    public bool smart;

    public void SetNewEffect(EffectType type)
    {
        Effect = new Effect() { type = type, stage = 1 };
        GetComponent<SpriteRenderer>().color = ColorConverter.ToColor(type);
    }
}
[System.Serializable]
public class Effect
{
    public EffectType type;
    public int stage;
}

