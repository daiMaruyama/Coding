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

        // �J�������ɂ��鏰�������o
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

        // �����_���ȏ���I�ԁi�������ɕ����o�������Ȃ��Ȃ�A�o���������L�^����j
        GameObject selectedPlatform = validPlatforms[Random.Range(0, validPlatforms.Count)];

        Vector3 spawnPos = selectedPlatform.transform.position;
        spawnPos.y += 0.5f;

        Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
    }
}
