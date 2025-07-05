using UnityEngine;

[CreateAssetMenu(fileName = "NewQuiz", menuName = "Quiz/QuizData")]
public class QuizData : ScriptableObject
{
    public string question;
    public string[] answer = new string[4]; //�N�C�Y�̐�
    public int correctIndex;
}
