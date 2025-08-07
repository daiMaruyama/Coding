using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlapperManager : MonoBehaviour
{
    [SerializeField] GameObject _gameOverText;
    [SerializeField] GameObject _retryText;
    [SerializeField] GameObject _bestText;
    bool _isGameOver = false;

    private void Update()
    {
        if (_isGameOver && Input.GetKeyDown(KeyCode.Return))
        {
            string nowScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(nowScene);
        }
    }

    public void GameOver()
    { 
        _gameOverText.SetActive(true);
        _retryText.SetActive(true);
        _bestText.SetActive(true);

        int best = PlayerPrefs.GetInt("BestScore", 0);
        Text bestScoreText = _bestText.GetComponent<Text>();
        if (bestScoreText != null)
        {
            bestScoreText.text = $"Best: {best}";
        }

        _isGameOver = true;
    }
}
