using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoguePlayer : MonoBehaviour
{
    private Vector2Int position;
    ItemBase2D heldItem;

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldItem != null)
            {
                Debug.Log("Eキーでアイテム使用: " + heldItem.name);
                heldItem.Activate();
                heldItem = null;
            }
            else
            {
                Debug.Log("Eキー押したけどアイテム持っていない");
            }
        }
    }

    Vector3 MapToWorld(Vector2Int pos)
    {
        return new Vector3(pos.x, pos.y, 0);
    }

    bool IsInMap(Vector2Int pos, bool[,] map)
    {
        return pos.x >= 0 && pos.x < map.GetLength(0)
            && pos.y >= 0 && pos.y < map.GetLength(1);
    }
    public void GetItem(ItemBase2D item)
    {
        heldItem = item;
        Debug.Log("アイテムを取得");
    }
}
