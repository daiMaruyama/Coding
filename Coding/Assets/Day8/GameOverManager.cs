using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject _gameOverPanel;

    public void ShowGameOver()
    {
        _gameOverPanel.SetActive(true); // UI��ON
        Time.timeScale = 0f; // �Q�[��������~
    }
}
