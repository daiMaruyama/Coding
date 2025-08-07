using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDuck : MonoBehaviour
{
    [SerializeField]@Text _scoreText;
    public int _score;

    public void AddScore(int point)
    {
        _score += point;
        _scoreText.text = _score.ToString();
        int best = PlayerPrefs.GetInt("BestScore", 0);
        if (_score > best)
        {
            PlayerPrefs.SetInt("BestScore", _score);
            PlayerPrefs.Save();
        }
    }
}
