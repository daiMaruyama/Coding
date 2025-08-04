using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    [SerializeField] PipeController _pipePrefab;
    [SerializeField] float _spawnTime = 2f;
    float _timer = 0f;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _spawnTime)
        {
            Spawn();
            _timer = 0f;
        }
    }

    void Spawn()
    {
        Instantiate(_pipePrefab, transform.position, Quaternion.identity);
    }
}
