using UnityEngine;

public class EnemyFallDetector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("�G���n�ʂɗ��� �� �~�X");
            ScoreManager.instance.Miss();
            Destroy(gameObject);
        }
    }
}
