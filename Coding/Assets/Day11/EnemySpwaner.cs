using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Camera _mainCam;
    [SerializeField] float _spawnInterval = 3f;
    [SerializeField] int _maxEnemiesInView = 2;

    float _timer;

    void Start()
    {
        if (_mainCam == null)
        {
            _mainCam = Camera.main;
        }
        _timer = _spawnInterval;
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            if (CountEnemiesInCameraView() < _maxEnemiesInView)
            {
                SpawnEnemyInCameraView();
            }
            _timer = _spawnInterval;
        }
    }

    void SpawnEnemyInCameraView()
    {
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Ground");
        if (platforms.Length == 0) return;

        float camTop = _mainCam.transform.position.y + _mainCam.orthographicSize;
        float camBottom = _mainCam.transform.position.y - _mainCam.orthographicSize;

        var validPlatforms = new System.Collections.Generic.List<GameObject>();
        foreach (GameObject platform in platforms)
        {
            float y = platform.transform.position.y;
            if (y > camBottom && y < camTop)
            {
                validPlatforms.Add(platform);
            }
        }

        if (validPlatforms.Count == 0) return;

        GameObject selectedPlatform = validPlatforms[Random.Range(0, validPlatforms.Count)];
        Vector3 spawnPos = selectedPlatform.transform.position;
        spawnPos.y += 0.5f;

        Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
    }

    int CountEnemiesInCameraView()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float camTop = _mainCam.transform.position.y + _mainCam.orthographicSize;
        float camBottom = _mainCam.transform.position.y - _mainCam.orthographicSize;

        int count = 0;
        foreach (GameObject enemy in enemies)
        {
            float y = enemy.transform.position.y;
            if (y > camBottom && y < camTop)
            {
                count++;
            }
        }
        return count;
    }
}
