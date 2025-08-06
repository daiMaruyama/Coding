using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlapperManager : MonoBehaviour
{
    [SerializeField] GameObject _gameOverText;
    [SerializeField] GameObject _retryText;
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
        _isGameOver = true;
    }
}
