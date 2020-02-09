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

public enum Colors
{
    White,
    Red,
    Green,
    Yellow,
    Blue,
    Black
}

public class ColorConverter
{
    public static Color ToColor(Colors s)
    {
        switch (s)
        {
            case Colors.Black:
                return Color.black;
            case Colors.Blue:
                return Color.blue;
            case Colors.Green:
                return Color.green;
            case Colors.Red:
                return Color.red;
            case Colors.Yellow:
                return Color.yellow;
            default:
                return Color.white;
        }
    }
}