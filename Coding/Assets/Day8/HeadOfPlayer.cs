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
        Rigidbody2D enemyRb = collision.GetComponent<Rigidbody2D>();　//当たったやつから取得
        if(enemyRb != null)
        {
            enemyRb.velocity = Vector2.zero;
            enemyRb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
            Debug.Log("ヘディング成功");
            ScoreManager.instance.AddScore();
            Destroy(collision.gameObject, 0.3f);
        }
    }
}
