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
                return new Color32(255, 218, 0, 255);
            case EffectType.Freeze:
                return new Color32(77, 191, 255, 255);
            case EffectType.Poison:
                return new Color32(29, 255, 180, 255); ;
            default:
                return Color.white;
        }
    }
    public static Color black = new Color32(31, 31, 56, 255);
}