using UnityEngine;

public class NormalizeChecker : MonoBehaviour
{
    void Start()
    {
        int x = Random.Range(-5, 5);
        int y = Random.Range(-5, 5);
        Vector3 RandomV = new(x, y, 0);
        Vector3 n = RandomV.Normalization();

        Debug.Log("ê≥ãKâªëOx: " + x);
        Debug.Log("ê≥ãKâªëOy: " + y);
        Debug.Log("ê≥ãKâªå„: " + n);
        Debug.Log("í∑Ç≥: " + n.magnitude);
    }
}
