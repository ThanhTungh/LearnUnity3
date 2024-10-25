using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeRemaining = 10f;
    [SerializeField] float timeToShowAnswer = 5f;
    public bool loadNextQuestion;
    public bool isAnsweringQuestion = false;
    public float fillTime;
    float timeValue;
    void Update()
    {
        UpdateTimer();
    }
    public void CancleTimer()
    {
        timeValue = 0;
    }
    void UpdateTimer()
    {
        timeValue -= Time.deltaTime;
        if(isAnsweringQuestion)
        {
            if(timeValue > 0)
            {
                fillTime = timeValue / timeRemaining;
            }
            else
            {
                isAnsweringQuestion = false;
                timeValue = timeToShowAnswer;
            }

        }
        else
        {

            if(timeValue > 0)
            {
                fillTime = timeValue / timeToShowAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timeValue = timeRemaining;
                loadNextQuestion = true;
            }
        }
        Debug.Log(timeValue);
    }

}
