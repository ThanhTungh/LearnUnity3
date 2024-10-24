using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeRemaining = 10f;
    [SerializeField] float timeToShowAnswer = 5f;
    public bool isAnsweringQuestion = false;    
    float timeValue;
    void Update()
    {
        UpdateTimer();
    }
    void UpdateTimer()
    {
        timeValue -= Time.deltaTime;
        if(isAnsweringQuestion)
        {
            if(timeValue <= 0)
            {
                isAnsweringQuestion = false;
                timeValue = timeToShowAnswer;
            }
            
        }
        else
        {
            if(timeValue <= 0)
            {
                isAnsweringQuestion = true;
                timeValue = timeRemaining;
            }
        }
        Debug.Log(timeValue);
    }
}
