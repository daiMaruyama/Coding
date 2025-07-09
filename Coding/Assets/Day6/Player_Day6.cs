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
        // ���E�ړ�
        float inputX = Input.GetAxisRaw("Horizontal");
        _speed.x = inputX * _moveSpeed;
        // �d��
        _speed.y -= _gravityScale * Time.deltaTime;
        // �W�����v
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
        {
            _speed.y = _jumpPower;
        }
        // �ʒu������
        transform.position += (Vector3)(_speed * Time.deltaTime);

        // �����蔻��ƃ}�O�}�ɗ������玸�s
        // �n�ʃ`�F�b�N�i���O��"Ground"�Ƃ���j
        _isGrounded = CheckCollisionWith("Ground");
        if (_isGrounded && _speed.y < 0) _speed.y = 0;

        // �}�O�}�`�F�b�N�i���O��"Lava"�Ƃ���j
        if (CheckCollisionWith("Magma"))
        {
            Debug.Log("�Q�[���I�[�o�[�F�}�O�}�ɗ������I");
            _gameOverText.SetActive(true);
            Destroy(gameObject); // ������
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

            // �C�� SpriteRenderer ����T�C�Y���擾
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
