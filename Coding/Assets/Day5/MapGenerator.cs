using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public static MapGenerator Instance { get; private set; }

    public bool[,] Map => _map;

    [SerializeField] private int _width = 10;
    [SerializeField] private int _height = 10;
    [SerializeField] private GameObject _floor;
    [SerializeField] private GameObject _wall;

    private bool[,] _map;

    void Awake()
    {
        Instance = this;
        GenerateMap();
        DrawMap();
    }

    void GenerateMap()
    {
        _map = new bool[_width, _height];

        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                if (x == 0 || y == 0 || x == _width - 1 || y == _height - 1)
                {
                    _map[x, y] = false; // 壁
                }
                else
                {
                    _map[x, y] = Random.value > 0.2f; // 80%が床
                }
            }
        }
    }

    void DrawMap()
    {
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                GameObject prefab = _map[x, y] ? _floor : _wall;
                Vector3 position = new Vector3(x, y, 0); // オフセットなし！
                Instantiate(prefab, position, Quaternion.identity, this.transform);
            }
        }
    }

    public Vector2Int GetSafeSpawnPosition()
    {
        List<Vector2Int> safeFloors = new List<Vector2Int>();

        for (int y = 1; y < _height - 1; y++)
        {
            for (int x = 1; x < _width - 1; x++)
            {
                if (!_map[x, y]) continue;

                if (_map[x + 1, y] || _map[x - 1, y] || _map[x, y + 1] || _map[x, y - 1])
                {
                    safeFloors.Add(new Vector2Int(x, y));
                }
            }
        }

        if (safeFloors.Count > 0)
        {
            return safeFloors[Random.Range(0, safeFloors.Count)];
        }

        return new Vector2Int(_width / 2, _height / 2);
    }
}
