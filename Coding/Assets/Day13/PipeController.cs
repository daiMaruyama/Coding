using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 10f;

    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * _moveSpeed;
    }
}
