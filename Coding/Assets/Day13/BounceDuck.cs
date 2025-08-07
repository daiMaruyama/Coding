using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceDuck : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _jumpPower = 5.0f;
    [SerializeField] ScoreDuck _score;
    [SerializeField] FlapperManager flapperManager;
    bool _isDead = false;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_isDead) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = Vector3.up * _jumpPower;
        }
        if (transform.position.y >= 14 || transform.position.y <= -14 )
        {
            ShowGameOver();
        }
    }

    void ShowGameOver()
    {
        flapperManager.GameOver();
        _isDead = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ShowGameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isDead) return;
        _score.AddScore(1);
    }
}
