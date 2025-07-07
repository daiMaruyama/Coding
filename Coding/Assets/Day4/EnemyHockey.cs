using UnityEngine;

public class EnemyHockey : MonoBehaviour
{
    [SerializeField] private Transform _puck;
    [SerializeField] private float _moveSpeed = 4.5f;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_puck == null) return;

        // ƒpƒbƒN‚Ì•ûŒü‚ÖˆÚ“®
        Vector2 direction = (_puck.position - transform.position).normalized;
        _rb.velocity = direction * _moveSpeed;

        //ˆÚ“®”ÍˆÍ§ŒÀ
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -3.5f, 3.5f);
        pos.y = Mathf.Clamp(pos.y, 1.0f, 4.3f);
        transform.position = pos;
    }
}
