using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �{�[���𐧌䂷��R���|�[�l���g�B�{�[���̃I�u�W�F�N�g�ɒǉ����Ďg���B
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class BallController1 : MonoBehaviour
{
    [SerializeField] Vector2 _powerDirection = Vector2.up + Vector2.right;
    [SerializeField] float _power = 5f;
    [SerializeField] float _maxSpeed = 3f;
    [SerializeField] float _shakePower = 5f;
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        // �{�[���𓮂���
        Push();
    }

    void Update()
    {
        // �{�[���̑��x�𐧌�����
        if (_rb.velocity.magnitude > _maxSpeed)
        {
            _rb.velocity = _rb.velocity.normalized * _maxSpeed;
        }

        // �X�y�[�X�L�[�������ƁA�����_���ȕ����ɗ͂�������
        if (Input.GetButtonDown("Jump"))
        {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            Vector2 dir = Vector2.right * x + Vector2.up * y;
            dir = dir.normalized;
            _rb.AddForce(dir * _shakePower, ForceMode2D.Impulse);

            // �J������h�炷
            CamController camera = Camera.main.GetComponent<CamController>(); // Camera.main �Ń��C���J������ GameObject ���擾�ł���
            camera.Shake();
        }
    }

    /// <summary>
    /// �{�[���ɗ͂�������
    /// </summary>
    public void Push()
    {
        _rb.AddForce(_powerDirection.normalized * _power, ForceMode2D.Impulse);
    }

    /// <param name="collision">�Փˏ��</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        RainbowBlock block = collision.gameObject.GetComponent<RainbowBlock>();
        if (block != null)
        {
            block.OnHit();
        }
    }

    /// <param name="collision">�ڐG���</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // OnCollisionEnter2D �Ɠ����̏���������
        RainbowBlock block = collision.gameObject.GetComponent<RainbowBlock>();
        if (block != null)
        {
            block.OnHit();
        }
    }
}