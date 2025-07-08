using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _goal;

    void Start()
    {
        // Floor�I�u�W�F�N�g��S���擾�i�^�O�� "Ground" �̂��́j
        GameObject[] floorList = GameObject.FindGameObjectsWithTag("Ground");

        if (floorList.Length == 0)
        {
            Debug.LogWarning("Floor��������܂���");
            return;
        }

        // �����_����1�I��
        int Index = Random.Range(0, floorList.Length);
        Vector3 spawnPos = floorList[Index].transform.position;

        Instantiate(_goal, spawnPos, Quaternion.identity);
    }
}
