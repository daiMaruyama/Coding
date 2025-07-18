using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : ItemBase2D
{
    [SerializeField] int healAmount = 10;
    public override void Activate()
    {
        Debug.Log($"プレイヤーのHPを{healAmount}回復！");
        // 実際の回復処理はここに書く
        PlayerStatus _status = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        if (_status != null)
        {
            _status.Heal(healAmount);
        }
        else
        {
            Debug.LogWarning("PlayerStatusが見つからない");
        }
    }
}
