using UnityEngine;

public class PlayerDay3 : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint; 
    [SerializeField] private GameObject _ballPrefab; 
    [SerializeField] private float _shootSpeed = 10f;
    [SerializeField] private LineRenderer _lineRenderer;
    private bool _hasShot = false;

    void Update()
    {
        Vector3 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Inputしたときのマウスポジション
        _mousePos.z = 0f; //2D

        Vector3 _shootDirection = (_mousePos - _shootPoint.position).normalized; //muzzleとのベクトルを取る

        //補助線を描く
        _lineRenderer.SetPosition(0, _shootPoint.position);
        _lineRenderer.SetPosition(1, _shootPoint.position + _shootDirection * 2f);

        if (!_hasShot && Input.GetButtonDown("Fire1"))
        {
            GameObject ball = Instantiate(_ballPrefab, _shootPoint.position, Quaternion.identity);
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            rb.velocity = _shootDirection * _shootSpeed;

            Ball ballScript = ball.GetComponent<Ball>();
            ballScript.SetStartX(_shootPoint.position.x);

            _hasShot = true;
        }

    }
}
