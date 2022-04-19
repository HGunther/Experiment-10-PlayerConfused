using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGenerator { 
    public static Color IndexToColor(int i)
    {
        var golden_ratio_conjugate = 0.618033988749895f;
        var hue = 0.1234f; // Random start value
        hue += golden_ratio_conjugate * i;
        hue %= 1;
        var saturation = 0.5f;
        var value = 0.95f;

        return Color.HSVToRGB(hue, saturation, value);
    }
}
