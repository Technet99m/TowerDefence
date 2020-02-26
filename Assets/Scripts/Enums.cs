using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Shapes
{
    Rectangle = 0,
    Triangle,
    Circle,
    Hexagon
}
public enum Targeting
{
    Weakest,
    Strongest,
    Nearest
}
public enum EffectType
{
    No = 0,
    Poison,
    Freeze,
    Lightning,
}

public class ColorConverter
{
    public static Color ToColor(EffectType ef)
    {
        switch (ef)
        {
            case EffectType.Lightning:
                return Color.yellow;
            case EffectType.Freeze:
                return Color.blue;
            case EffectType.Poison:
                return Color.green;
            default:
                return Color.white;
        }
    }
}