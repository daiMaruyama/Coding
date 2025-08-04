using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDuck : MonoBehaviour
{
    [SerializeField]Å@Text _scoreText;
    int _score;

    public void AddScore(int point)
    {
        _score += point;
        _scoreText.text = _score.ToString();
    }
}
