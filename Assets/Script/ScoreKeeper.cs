using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswer = 0;
    int questionsSeen = 0;

    public int GetCorrectAnswer()//getter function
    {
        return correctAnswer;
    }
    public void AddCorrectAnswer()//setter function
    {
        correctAnswer++;
    }

    public int GetQuestionSeen()//getter function
    {
        return questionsSeen;
    }
    public void AddQuestionSeen()//setter function
    {
        questionsSeen++;
    }
    public int CaculateScore()
    {
        return Mathf.RoundToInt(correctAnswer / (float)questionsSeen * 100);
    }
}
