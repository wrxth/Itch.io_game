using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogProjector : MonoBehaviour
{
    public Color[] GetSmoothlyFilledCircle(int r)
    {
        int diameter = 2 * r;
        Color[] pixels = new Color[diameter * diameter];
        for (int x = 0; x < diameter; x++)
        {
            for (int y = 0; y < diameter; y++)
            {
                float distanceToCenter = Mathf.Sqrt(Mathf.Pow(r - x, 2) + Mathf.Pow(r - y, 2));
                float normalizedDistance = distanceToCenter / r;
                int index = y + (diameter * x);
                pixels[index] = Color.white * normalizedDistance;
            }
        }
        return pixels;
    }
}
