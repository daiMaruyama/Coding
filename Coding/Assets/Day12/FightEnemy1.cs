using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightEnemy1 : MonoBehaviour
{
    Animator _animator;
    public int _enemyHp = 3;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnDamage(int damage)
    {
        _enemyHp -= damage;
        _animator.SetTrigger("Attacked");
        _animator.SetTrigger("Idle");
        if (_enemyHp <= 0)
        {
            Die();
        }

    }
    private void Die()
    {
        _enemyHp = 0;
        _animator.SetTrigger("Die");
    }
}
