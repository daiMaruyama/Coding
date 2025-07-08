using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoguePlayer : MonoBehaviour
{
    private Vector2Int position;

    void Start()
    {
        position = MapGenerator.Instance.GetSafeSpawnPosition();
        transform.position = MapToWorld(position);
    }

    void Update()
    {
        Vector2Int move = Vector2Int.zero;

        if (Input.GetKeyDown(KeyCode.W)) move = Vector2Int.up;
        if (Input.GetKeyDown(KeyCode.A)) move = Vector2Int.left;
        if (Input.GetKeyDown(KeyCode.S)) move = Vector2Int.down;
        if (Input.GetKeyDown(KeyCode.D)) move = Vector2Int.right;

        Vector2Int next = position + move;
        bool[,] map = MapGenerator.Instance.Map;

        if (IsInMap(next, map) && map[next.x, next.y])
        {
            position = next;
            transform.position = MapToWorld(position);
        }
    }

    Vector3 MapToWorld(Vector2Int pos)
    {
        return new Vector3(pos.x, pos.y, 0); // •â³‚È‚µ
    }

    bool IsInMap(Vector2Int pos, bool[,] map)
    {
        return pos.x >= 0 && pos.x < map.GetLength(0)
            && pos.y >= 0 && pos.y < map.GetLength(1);
    }
}
