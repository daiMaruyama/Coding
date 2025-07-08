using UnityEngine;

public class NormalizeChecker : MonoBehaviour
{
    void Start()
    {
        int x = Random.Range(-5, 5);
        int y = Random.Range(-5, 5);
        Vector3 RandomV = new(x, y, 0);
        Vector3 n = RandomV.Normalization();

        Debug.Log("���K���Ox: " + x);
        Debug.Log("���K���Oy: " + y);
        Debug.Log("���K����: " + n);
        Debug.Log("����: " + n.magnitude);
    }
}
