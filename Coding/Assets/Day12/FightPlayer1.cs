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
    private int _attackPower = 1;
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
        float moveX = Input.GetAxisRaw("Horizontal");

        if (moveX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (moveX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        _rb.velocity = new Vector2(moveX * _moveSpeed, _rb.velocity.y);

        _animator.SetFloat("Speed", Mathf.Abs(_rb.velocity.x));
    }

    void Attack()
    {
        _animator.SetTrigger("Attack");

        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(_attackMuzzle.position, _attackRadious, _enemyLayerMask);
        foreach (Collider2D hitEnemy in hitEnemys)
        {
            Debug.Log(hitEnemy.gameObject.name + "‚ÉAttack");
            hitEnemy.GetComponent<FightEnemy1>().OnDamage(_attackPower);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackMuzzle.position, _attackRadious);
    }
}
