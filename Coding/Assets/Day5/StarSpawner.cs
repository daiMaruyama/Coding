using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _goal;

    void Start()
    {
        // Floorオブジェクトを全部取得（タグが "Ground" のもの）
        GameObject[] floorList = GameObject.FindGameObjectsWithTag("Ground");

        if (floorList.Length == 0)
        {
            Debug.LogWarning("Floorが見つかりません");
            return;
        }

        // ランダムに1つ選ぶ
        int Index = Random.Range(0, floorList.Length);
        Vector3 spawnPos = floorList[Index].transform.position;

        Instantiate(_goal, spawnPos, Quaternion.identity);
    }
}
