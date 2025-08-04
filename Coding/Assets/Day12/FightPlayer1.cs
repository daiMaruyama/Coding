using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPlayer1 : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3f;
    Rigidbody2D _rb;
    Animator _animator;
    [SerializeField] Transform _attackMuzzle;
    [SerializeField] float _attackRadious;
    [SerializeField] LayerMask _enemyLayerMask;
    int _attackPower = 1;
    int _playerHp = 5;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _animator.SetTrigger("Idle");
        }
        Move();
    }

    void Move()
    {
        float moveX = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
            transform.localScale = new Vector3(1, 1, 1);
        }

        _rb.velocity = new Vector2(moveX * _moveSpeed, _rb.velocity.y);
        _animator.SetFloat("Speed", Mathf.Abs(moveX)); // moveXを直接使ってOK
    }


    void Attack()
    {
        _animator.SetTrigger("Attack");

        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(_attackMuzzle.position, _attackRadious, _enemyLayerMask);
        foreach (Collider2D hitEnemy in hitEnemys)
        {
            Debug.Log(hitEnemy.gameObject.name + "にAttack");
            hitEnemy.GetComponent<FightEnemy1>().OnDamage(_attackPower);
        }
    }
    public void OnDamage(int damage)
    {
        _playerHp -= damage;
        _animator.SetTrigger("Attacked");

        if (_playerHp <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        _playerHp = 0;
        _animator.SetTrigger("Die");
        Debug.Log("プレイヤー死亡！");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackMuzzle.position, _attackRadious);
    }
}
