using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizData[] _quizList;              // クイズの配列
    [SerializeField] private TextMeshProUGUI _questionText;     // 問題文表示用
    [SerializeField] private TextMeshProUGUI[] _choiceTexts;    // 選択肢表示用（4つ）

    private int _currentIndex = 0;
    //private int _score = 0;

    private void Start()
    {
        ShowNextQuestion();
    }

    private void ShowNextQuestion()
    {
        if (_currentIndex >= _quizList.Length)
        {
            //ShowResult();
            return;
        }

        var quiz = _quizList[_currentIndex];

        _questionText.text = quiz.question;

        for (int i = 0; i < _choiceTexts.Length; i++)
        {
            _choiceTexts[i].text = quiz.answer[i];
        }
    }

    /*
    public void Answer(int selectedIndex)
    {
        if (selectedIndex == _quizList[_currentIndex].correctIndex)
        {
            Debug.Log("正解！");
            _score++;
        }
        else
        {
            Debug.Log("不正解！");
        }

        _currentIndex++;
        ShowNextQuestion();
    }

    private void ShowResult()
    {
        Debug.Log($"クイズ終了！正解数: {_score}");

        if (_score == _quizList.Length)
        {
            Debug.Log("満点！最強！");
        }
        else if (_score >= 3)
        {
            Debug.Log("いい感じ！");
        }
        else
        {
            Debug.Log("もっとがんばろう！");
        }
    } */
}
