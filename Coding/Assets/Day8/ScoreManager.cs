using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI _missText;
    [SerializeField] int _missCount = 0;
    [SerializeField] int _maxMissCount = 5;
    int _score = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void AddScore()
    {
        _score++;
        UIUpdate();
    }

    public void Miss()
    {
        _missCount++;
        UIUpdate();
        if (_missCount >= _maxMissCount)
        {
            FindObjectOfType<GameOverManager>().ShowGameOver(); // åƒÇ—èoÇ∑
            Debug.Log("GameOver");
        }
    }

    public void UIUpdate()
    {
        _scoreText.text = $"Score: {_score}";
        _missText.text = $"Miss: {_missCount} / {_maxMissCount}";
    }
}
