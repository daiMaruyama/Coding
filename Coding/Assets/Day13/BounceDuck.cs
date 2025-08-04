using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceDuck : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _jumpPower = 5.0f;
    [SerializeField] ScoreDuck _score;
    [SerializeField] FlapperManager flapperManager;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = Vector3.up * _jumpPower;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        flapperManager.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _score.AddScore(1);
    }
}
