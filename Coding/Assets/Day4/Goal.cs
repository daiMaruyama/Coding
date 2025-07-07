using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    [SerializeField] private bool _isGoal = false; // trueなら自分のゴール（失点）

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Puck"))
        {
            if (_isGoal)
            {
                Debug.Log("自分のゴールに入った！負け！");
                // TODO: ここで敗北演出・シーン遷移・再試行など
            }
            else
            {
                Debug.Log("敵ゴールに入れた！勝ち！");
                // TODO: ここで勝利演出・スコア加算など
            }

            // ゲーム停止（あとでボタンで再開 or リスタート）
            Time.timeScale = 0f;
        }
    }
}
