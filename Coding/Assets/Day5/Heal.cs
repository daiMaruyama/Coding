using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : ItemBase2D
{
    [SerializeField] int healAmount = 10;
    public override void Activate()
    {
        Debug.Log($"�v���C���[��HP��{healAmount}�񕜁I");
        // ���ۂ̉񕜏����͂����ɏ���
        PlayerStatus _status = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        if (_status != null)
        {
            _status.Heal(healAmount);
        }
        else
        {
            Debug.LogWarning("PlayerStatus��������Ȃ�");
        }
    }
}
