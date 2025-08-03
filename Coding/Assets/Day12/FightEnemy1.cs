using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightEnemy1 : MonoBehaviour
{
    Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnDamage()
    {
        _animator.SetTrigger("Attacked");
        _animator.SetTrigger("Idle");
    }
}
