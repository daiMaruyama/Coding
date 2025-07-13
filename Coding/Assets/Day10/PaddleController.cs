using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>��ΕK�v�ŁA�Ȃ���Βǉ�</summary>
[RequireComponent(typeof(Rigidbody2D))]

public class PaddleController : MonoBehaviour
{
    Rigidbody2D _rb;
    /// <summary>�p�h���̈ړ����x</summary>
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
