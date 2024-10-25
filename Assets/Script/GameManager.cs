using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quizz;
    EndScreen endScreen;

    void Awake()
    {
        quizz = FindObjectOfType<Quiz>();
        endScreen = FindObjectOfType<EndScreen>();
    }
    void Start()
    {
        quizz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
    }

    void Update()
    {
        if(quizz.isComplate)
        {
            quizz.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
            endScreen.ShowFinalScore();
        }
    }

    public void OnRePlayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
