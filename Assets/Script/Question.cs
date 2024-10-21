using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class Question : ScriptableObject
{
    [TextArea(2, 6)]//TextArea attribute allows us to specify the number of lines and characters for the text area
    [SerializeField] string question = "Enter question here";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex;

    public string GetQuestion()
    {
        return question;
    }
    public int GetCorrectAnswer()
    {
        return correctAnswerIndex;
    }
    public string GetAnswer(int index)
    {
        return answers[index];
        
    }
}
