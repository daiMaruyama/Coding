using UnityEngine;

public class PlayerByCross : MonoBehaviour
{
    [SerializeField] float _jumpPower = 5f;
    [SerializeField] int _maxJumpCount = 2;
    [SerializeField] float _moveSpeed = 3f;
    // [SerializeField] float _power = 5f;
    int _jumpCount = 0;
    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveX = 0f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        else if (Input.GetKey(KeyCode.D)) moveX = 1f;

        Vector2 velocity = _rb.velocity;
        velocity.x = moveX * _moveSpeed;
        _rb.velocity = velocity;

        // 早期リターンの練習
        if (!Input.GetKeyDown(KeyCode.Space)) return; // ジャンプキー押されてなければreturn
        if (_jumpCount >= _maxJumpCount) return; // _maxJumpCount超えたらreturn

        Jump();
    }

    private void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, 0f);
        _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        _jumpCount++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _jumpCount = 0;
        }
        //  tag違うならreturn
        if (!collision.gameObject.CompareTag("Enemy")) return;

        /* 
        ContactPoint2D contact = collision.contacts[0];
        Vector2 normal = contact.normal.normalized;
        Vector2 velocity = _rb.velocity.normalized;
        float angle = Vector2.Angle(velocity, normal);
        Debug.Log($"Angle: {angle}, Velocity: {velocity}, Normal: {normal}");
        // float crossZ = Vector3.Cross(-velocity, normal).z;

        if (0f < angle || angle  < 45f)
        {
            Rigidbody2D enemyRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (enemyRb != null)
            {
                enemyRb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            }
            Debug.Log("ヘディング成功 → 敵を上に飛ばして消す");
            Destroy(collision.gameObject, 0.3f); // エフェクト猶予付き破壊
        }
        */
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("ヘディング失敗（頭以外）");
            ScoreManager.instance.Miss();
            Destroy(collision.gameObject, 0.3f);
        }
    }
}
