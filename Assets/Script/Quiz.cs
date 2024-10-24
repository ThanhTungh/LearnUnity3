using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] Question questions;
    
    [Header("Answer")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;

    [Header("Button Color")]
    [SerializeField] Sprite DefaultAnswer;
    [SerializeField] Sprite CorrectAnswer;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        //DisplayQuestion();
        GetNextQuestion();

        
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillTime;
    }       
    void DisplayQuestion(){
        questionText.text = questions.GetQuestion();

        for(int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI answerText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            answerText.text = questions.GetAnswer(i);
        }
    }
    public void AnswerButtonClicked(int index)
    {
        Image buttonImage;

        if(index == questions.GetCorrectAnswer())
        {
            questionText.text = "Correct!";
            //answerButtons[index].GetComponent<Image>().sprite = CorrectAnswer;
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = CorrectAnswer;
        }
        else
        {
            // questionText.text = answerButtons[questions.GetCorrectAnswer()].GetComponentInChildren<TextMeshProUGUI>().text;
            // Image buttonImage = answerButtons[questions.GetCorrectAnswer()].GetComponent<Image>();
            // buttonImage.sprite = CorrectAnswer;

            correctAnswerIndex = questions.GetCorrectAnswer();
            string correctAnswer = questions.GetAnswer(correctAnswerIndex);
            questionText.text = "Incorrect! The correct answer is: " + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = CorrectAnswer;
        }
        
        SetButtonState(false);
    }
    
    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprite();
        DisplayQuestion();
        
    }

    void SetButtonState(bool state)
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprite()
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = DefaultAnswer;
        }
    }
}
