using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] float _spawnTime = 3f;
    [SerializeField] float _xRange = 3f;
    [SerializeField] float _y = 5f;
    [SerializeField] GameObject _ball;

    void Start()
    {
        InvokeRepeating(nameof(BallSpawn), 0f, _spawnTime);
    }

    void BallSpawn()
    {
        float randX = Random.Range(-2 * _xRange, _xRange);
        Vector2 spawnPos = new Vector2(randX, _y);
        Instantiate(_ball, spawnPos, Quaternion.identity);
    }
}
