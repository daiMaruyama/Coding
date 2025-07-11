using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject _gameOverPanel;

    public void ShowGameOver()
    {
        _gameOverPanel.SetActive(true); // UI‚ğON
        Time.timeScale = 0f; // ƒQ[ƒ€‹­§’â~
    }
}
