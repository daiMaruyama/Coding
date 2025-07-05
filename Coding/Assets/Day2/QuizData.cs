using UnityEngine;

[CreateAssetMenu(fileName = "NewQuiz", menuName = "Quiz/QuizData")]
public class QuizData : ScriptableObject
{
    public string question;
    public string[] answer = new string[4]; //ƒNƒCƒY‚Ì”
    public int correctIndex;
}
