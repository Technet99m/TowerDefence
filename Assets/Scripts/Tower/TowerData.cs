using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerData : MonoBehaviour
{
    public float Range, Damage, Reload, BulletSpeed;
    public Effect Effect;
    public Shapes Shape;
    public bool smart;
    public TowerAim aim;
    public void SetNewEffect(EffectType type)
    {
        Effect = new Effect() { type = type, stage = 1 };
        GetComponent<SpriteRenderer>().color = ColorConverter.ToColor(type);
    }
}
[System.Serializable]
public class Effect
{
    public const float MAX_STAGE = 5f;
    public EffectType type;
    public int stage;
}

