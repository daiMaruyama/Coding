using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボールを制御するコンポーネント。ボールのオブジェクトに追加して使う。
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class BallController1 : MonoBehaviour
{
    [SerializeField] Vector2 _powerDirection = Vector2.up + Vector2.right;
    [SerializeField] float _power = 5f;
    [SerializeField] float _maxSpeed = 3f;
    [SerializeField] float _shakePower = 5f;
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        // ボールを動かす
        Push();
    }

    void Update()
    {
        // ボールの速度を制限する
        if (_rb.velocity.magnitude > _maxSpeed)
        {
            _rb.velocity = _rb.velocity.normalized * _maxSpeed;
        }

        // スペースキーを押すと、ランダムな方向に力を加える
        if (Input.GetButtonDown("Jump"))
        {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            Vector2 dir = Vector2.right * x + Vector2.up * y;
            dir = dir.normalized;
            _rb.AddForce(dir * _shakePower, ForceMode2D.Impulse);

            // カメラを揺らす
            CamController camera = Camera.main.GetComponent<CamController>(); // Camera.main でメインカメラの GameObject を取得できる
            camera.Shake();
        }
    }

    /// <summary>
    /// ボールに力を加える
    /// </summary>
    public void Push()
    {
        _rb.AddForce(_powerDirection.normalized * _power, ForceMode2D.Impulse);
    }

    /// <param name="collision">衝突情報</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        RainbowBlock block = collision.gameObject.GetComponent<RainbowBlock>();
        if (block != null)
        {
            block.OnHit();
        }
    }

    /// <param name="collision">接触情報</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // OnCollisionEnter2D と同じの処理をする
        RainbowBlock block = collision.gameObject.GetComponent<RainbowBlock>();
        if (block != null)
        {
            block.OnHit();
        }
    }
}