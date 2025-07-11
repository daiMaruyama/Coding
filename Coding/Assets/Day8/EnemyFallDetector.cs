using UnityEngine;

public class EnemyFallDetector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("“G‚ª’n–Ê‚É—‰º ¨ ƒ~ƒX");
            ScoreManager.instance.Miss();
            Destroy(gameObject);
        }
    }
}
