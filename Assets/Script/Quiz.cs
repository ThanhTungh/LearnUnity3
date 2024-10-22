using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] Question questions;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField] Sprite DefaultAnswer;
    [SerializeField] Sprite CorrectAnswer;
    void Start()
    {
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
    }

}
