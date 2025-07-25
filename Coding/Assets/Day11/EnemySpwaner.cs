using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Camera _mainCam;

    void Start()
    {
        if (_mainCam == null)
        {
            _mainCam = Camera.main;
        }

        SpawnEnemyInCameraView();
    }

    void SpawnEnemyInCameraView()
    {
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Ground");
        if (platforms.Length == 0) return;

        float camTop = _mainCam.transform.position.y + _mainCam.orthographicSize;
        float camBottom = _mainCam.transform.position.y - _mainCam.orthographicSize;

        // カメラ内にある床だけ抽出
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

        // ランダムな床を選ぶ（同じ床に複数出したくないなら、出した床を記録する）
        GameObject selectedPlatform = validPlatforms[Random.Range(0, validPlatforms.Count)];

        Vector3 spawnPos = selectedPlatform.transform.position;
        spawnPos.y += 0.5f;

        Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
    }
}
