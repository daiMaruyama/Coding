using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Day6 : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] float _jumpPower = 1f;
    [SerializeField] float _gravityScale = 10f;
    [SerializeField] GameObject _gameOverText;
    Vector2 _speed;
    bool _isGrounded;
    public float _width;
    public float _height;

    // Start is called before the first frame update
    void Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            _width = spriteRenderer.bounds.size.x;
            _height = spriteRenderer.bounds.size.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 左右移動
        float inputX = Input.GetAxisRaw("Horizontal");
        _speed.x = inputX * _moveSpeed;
        // 重力
        _speed.y -= _gravityScale * Time.deltaTime;
        // ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
        {
            _speed.y = _jumpPower;
        }
        // 位置動かす
        transform.position += (Vector3)(_speed * Time.deltaTime);

        // 当たり判定とマグマに落ちたら失敗
        // 地面チェック（名前で"Ground"とする）
        _isGrounded = CheckCollisionWith("Ground");
        if (_isGrounded && _speed.y < 0) _speed.y = 0;

        // マグマチェック（名前で"Lava"とする）
        if (CheckCollisionWith("Magma"))
        {
            Debug.Log("ゲームオーバー：マグマに落ちた！");
            _gameOverText.SetActive(true);
            Destroy(gameObject); // 消える
        }

    }

    bool CheckCollisionWith(string targetName)
    {
        Rect playerRect = new Rect(
            transform.position.x - _width / 2f,
            transform.position.y - _height / 2f,
            _width,
            _height
        );

        foreach (var obj in GameObject.FindGameObjectsWithTag("Check"))
        {
            if (obj.name != targetName) continue;

            Vector2 objPos = obj.transform.position;

            // 修正 SpriteRenderer からサイズを取得
            Vector2 objSize = Vector2.one;
            var renderer = obj.GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                objSize = renderer.bounds.size;
            }

            Rect objRect = new Rect(
                objPos.x - objSize.x / 2f,
                objPos.y - objSize.y / 2f,
                objSize.x,
                objSize.y
            );

            if (playerRect.Overlaps(objRect))
            {
                return true;
            }
        }

        return false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(_width, _height, 0));

        foreach (var obj in GameObject.FindGameObjectsWithTag("Check"))
        {
            var sr = obj.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(obj.transform.position, sr.bounds.size);
            }
        }
    }

}
