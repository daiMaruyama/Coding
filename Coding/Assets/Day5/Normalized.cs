using UnityEngine;

public static class Normalized
{
    public static Vector3 Normalization(this Vector3 v)
    {
        float maginitude = v.magnitude;
        if (maginitude > 0.0001f)
        {
            return v / maginitude;
        }
        else
        {
            return Vector3.zero;
        }
    }
}