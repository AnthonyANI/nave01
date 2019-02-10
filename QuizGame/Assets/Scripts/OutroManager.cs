using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class OutroManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    void Start()
    {
        scoreText.text = "Final Score:" + '\n' + GameManager.score + '/' + GameManager.questions.Length + " (" + Math.Round(((double)GameManager.score / ((double)GameManager.questions.Length - (double)GameManager.unansweredQuestions.Count())) * 100.0, 1) + "%)";
    }

    public void userSelectStart()
    {
        GameManager.ResetGame();
        SceneManager.LoadScene("Intro");
    }

    public void userSelectQuit()
    {
        Application.Quit();
    }
}
