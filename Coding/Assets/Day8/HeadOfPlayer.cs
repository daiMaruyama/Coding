using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadOfPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
        {
            return;
        }
        Rigidbody2D enemyRb = collision.GetComponent<Rigidbody2D>();�@//�������������擾
        if(enemyRb != null)
        {
            enemyRb.velocity = Vector2.zero;
            enemyRb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
            Debug.Log("�w�f�B���O����");
            ScoreManager.instance.AddScore();
            Destroy(collision.gameObject, 0.3f);
        }
    }
}
