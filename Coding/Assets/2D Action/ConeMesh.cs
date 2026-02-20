using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeMesh : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = new Mesh();
        float theta;
        Vector3[] point = new Vector3[13];

        point[0] = new Vector3 (0f, Data.range, 0f);
        for (int i = 1; i < 13; i++)
        {
            theta = (i - 1) * Mathf.PI / 6f;
            point[i] = new Vector3 (Data.height * Mathf.Cos(theta), 0f, Data.height * Mathf.Sin(theta));
        }
        mesh.SetVertices(point);

        int[] pointSet = new int[36];
        for (int j = 0; j < 12; j++)
        {
            pointSet[j * 3] = j + 1;
            pointSet[j * 3 + 1] = 0;
            pointSet[j * 3 + 2] = (pointSet[j * 3] + 1 );
        }
        pointSet[35] = 1;

        mesh.SetTriangles(pointSet, 0);

        MeshFilter filter = GetComponent<MeshFilter>();
        filter.sharedMesh = mesh;
    }
}
