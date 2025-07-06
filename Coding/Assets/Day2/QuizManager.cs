using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizData[] _quizList;              // �N�C�Y�̔z��
    [SerializeField] private TextMeshProUGUI _questionText;     // ��蕶�\���p
    [SerializeField] private TextMeshProUGUI[] _choiceTexts;    // �I�����\���p�i4�j

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
            Debug.Log("�����I");
            _score++;
        }
        else
        {
            Debug.Log("�s�����I");
        }

        _currentIndex++;
        ShowNextQuestion();
    }

    private void ShowResult()
    {
        Debug.Log($"�N�C�Y�I���I����: {_score}");

        if (_score == _quizList.Length)
        {
            Debug.Log("���_�I�ŋ��I");
        }
        else if (_score >= 3)
        {
            Debug.Log("���������I");
        }
        else
        {
            Debug.Log("�����Ƃ���΂낤�I");
        }
    } */
}
