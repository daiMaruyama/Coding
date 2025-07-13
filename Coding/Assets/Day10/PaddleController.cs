using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>絶対必要で、なければ追加</summary>
[RequireComponent(typeof(Rigidbody2D))]

public class PaddleController : MonoBehaviour
{
    Rigidbody2D _rb;
    /// <summary>パドルの移動速度</summary>
    [SerializeField] float m_speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        _rb.velocity = m_speed * h * Vector2.right;
    }
}
