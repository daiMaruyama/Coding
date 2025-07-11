using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float _minSpeed = 1f;
    [SerializeField] float _maxSpeed = 5f;
    private float _moveSpeed;
    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _moveSpeed = Random.Range(_minSpeed, _maxSpeed);
        int direction = Random.value < 0.5f ? -1 : 1;
        _moveSpeed *= direction;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.velocity = new Vector2(_moveSpeed, _rb.velocity.y);
    }
}
