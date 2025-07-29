using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Move2D : MonoBehaviour
{
    Rigidbody2D _rb2D;
    float _speed = 5f;
    void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        _rb2D.velocity = new Vector2(moveX * _speed, 0);
        if (moveX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveX), 1f, 1f);
        }
    }
}
