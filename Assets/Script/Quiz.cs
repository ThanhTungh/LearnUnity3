using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<Question> questions = new List<Question>();
    Question currentQuestion;
    
    [Header("Answer")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnswerEarly;

    [Header("Button Color")]
    [SerializeField] Sprite DefaultAnswer;
    [SerializeField] Sprite CorrectAnswer;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Progress Bar")]    
    [SerializeField] Slider progressBar;
    public bool isComplate;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillTime;
        if(timer.loadNextQuestion)
        {
            hasAnswerEarly = false;
            timer.loadNextQuestion = false;
            GetNextQuestion();
        }else if(!hasAnswerEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }      
    void DisplayQuestion(){
        questionText.text = currentQuestion.GetQuestion();

        for(int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI answerText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            answerText.text = currentQuestion.GetAnswer(i);
        }
    }
    public void AnswerButtonClicked(int index)
    {
        hasAnswerEarly = true;
        DisplayAnswer(index);
        
        SetButtonState(false);
        timer.CancleTimer();
        scoreText.text = "Score: " + scoreKeeper.CaculateScore() + "%";
        if(progressBar.value == progressBar.maxValue)
        {
            isComplate = true;
        }
    }
    void DisplayAnswer(int index)
    {
        Image buttonImage;

        if(index == currentQuestion.GetCorrectAnswer())
        {
            questionText.text = "Correct!";
            //answerButtons[index].GetComponent<Image>().sprite = CorrectAnswer;
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = CorrectAnswer;
            scoreKeeper.AddCorrectAnswer();
        }
        else
        {
            // questionText.text = answerButtons[questions.GetCorrectAnswer()].GetComponentInChildren<TextMeshProUGUI>().text;
            // Image buttonImage = answerButtons[questions.GetCorrectAnswer()].GetComponent<Image>();
            // buttonImage.sprite = CorrectAnswer;

            correctAnswerIndex = currentQuestion.GetCorrectAnswer();
            string correctAnswer = currentQuestion.GetAnswer(correctAnswerIndex);
            questionText.text = "Incorrect! The correct answer is: " + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = CorrectAnswer;
        }
    }
    
    void GetNextQuestion()
    {
        if(questions.Count > 0)
        {
            SetDefaultButtonSprite();
            SetButtonState(true);
            GetRandomQuestion();
            DisplayQuestion();
            progressBar.value++;
            scoreKeeper.AddQuestionSeen();
        }
        
    }

    void GetRandomQuestion()
    {
        int randomIndex = Random.Range(0, questions.Count);
        currentQuestion = questions[randomIndex];

        if(questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
        
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
