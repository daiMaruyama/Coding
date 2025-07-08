using UnityEngine;

public static class Normalized
{
    public static Vector3 Normalization(this Vector3 v)
    {
        float magnitude = v.magnitude;
        if (magnitude > 0.0001f)
        {
            return v / magnitude;
        }
        else
        {
            return v = Vector3.zero;
        }
    }
}