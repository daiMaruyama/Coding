using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Test : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float _speed = 5f;
    Rigidbody _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 direction = (target.position = _rb.position).normalized;
        Vector3 rotation = Vector3.Cross(transform.forward, direction);
        _rb.angularVelocity = new Vector3(0f, rotation.y, 0f);
        _rb.velocity = transform.forward * _speed;
    }
}
