using UnityEngine;

public class PlayerHockey : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(x, y).normalized;
        _rb.velocity = dir * moveSpeed;

        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -4.3f, 4.3f);
        pos.y = Mathf.Clamp(pos.y, -4.3f, -0.3f); // センターラインより下だけ
        transform.position = pos;
    }
}
