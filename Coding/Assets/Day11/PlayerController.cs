using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float jumpPower = 3f;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float deltaMove = 1.5f;
    [SerializeField] float maxChargeTime = 1f;
    float chargeTime = 0f;

    bool _isGrounded = false;
    bool _isFacingRight = true;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (_isGrounded) // �ڒn��
        {
            // �ڒn���̂݉��ړ�
            //_rb.velocity = new Vector3(moveInput * moveSpeed, _rb.velocity.y);
            if (moveInput > 0)
            {
                _isFacingRight = true;
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                transform.position += new Vector3(deltaMove * Time.deltaTime, 0, 0);
            }
            else if (moveInput < 0)
            {
                _isFacingRight = false;
                transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
                transform.position -= new Vector3(deltaMove * Time.deltaTime, 0, 0);
            }

            /*
            if (Input.GetButtonDown("Jump"))
            {
                // �����Ă�������ŃW�����v�i���͂Ȃ��ł� transform.localScale �ˑ��j
                // TODO �W�����v�L�[�̉�����Ă��鎞�Ԉˑ��Ńx�N�g���̌����Ƒ傫�������肵����
                Vector3 jumpDirection = _isFacingRight ? new Vector3(1f, 1.8f) : new Vector3(-1f, 1.8f);
                _rb.velocity = Vector3.zero;
                _rb.AddForce(jumpDirection.normalized * jumpPower, ForceMode2D.Impulse);
            }*/

            if (Input.GetButton("Jump")) // Jump�L�[�̓��͂�����Ƃ�
            {
                chargeTime += Time.deltaTime;
                if (chargeTime > maxChargeTime)
                {
                    chargeTime = maxChargeTime;
                }
            }

            if (Input.GetButtonUp("Jump")) // Jump�L�[�������[�X���ꂽ��
            {
                // ���ۂ̃`���[�W���Ԃƍő�`���[�W���Ԃ�0�`1�ŕԂ�
                float chargeGage = Mathf.Clamp01(chargeTime / maxChargeTime);
                // ��L��p���Ċp�x�𒲐��i�����ł�20�`70�j
                float radValue = Mathf.Lerp(20f, 70f, chargeGage);
                // �x���@�iRad�j�Ƃ��ĕϊ�
                float rad = radValue * Mathf.Deg2Rad;
                // �W�����v�̑傫�������l�ɒ���
                float power = Mathf.Lerp(jumpPower * 0.5f, jumpPower, chargeGage);
                float dirX = Mathf.Cos(rad) * (_isFacingRight ? 1 : -1);
                float dirY = Mathf.Sin(rad);
                Vector3 jumpDirection = new Vector3(dirX, dirY, 0f);
                _rb.velocity = Vector3.zero;
                _rb.AddForce(jumpDirection.normalized * power, ForceMode2D.Impulse);

                chargeTime = 0; // �`���[�W�^�C�����Z�b�g
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}
