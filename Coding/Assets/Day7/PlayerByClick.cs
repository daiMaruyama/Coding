using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerByClick : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 0.01f;
    [SerializeField] TextMeshProUGUI _distanceText;
    private float _distance = 0f;

    private bool _canMove = false;

    public float Distance => _distance; // 記録用に公開

    public void EnableInput(bool canMove)
    {
        _canMove = canMove;
    }
    public void ResetPlayer()
    {
        _distance = 0f;
        _distanceText.text = "0.00 m";
        transform.position = new Vector3(-4.75f, -0.80f, 0f); // 初期位置に戻す
    }

    void Update()
    {
        if (!_canMove) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector2.right * _moveSpeed);
            _distance += _moveSpeed;
            _distanceText.text = $"{_distance:F2} m";
        }
    }
}
