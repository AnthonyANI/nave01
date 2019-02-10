using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

public class GameManager : MonoBehaviour {
    public static Question[] questions;
    public static List<Question> unansweredQuestions;
    public static int score;

    private Question currentQuestion;

    [SerializeField]
    private string quizFile;

    [SerializeField]
    private Text questionText;

    [SerializeField]
    private Text answerAText;

    [SerializeField]
    private Text answerAResponse;

    [SerializeField]
    private Text answerBText;

    [SerializeField]
    private Text answerBResponse;

    [SerializeField]
    private Text answerCText;

    [SerializeField]
    private Text answerCResponse;

    [SerializeField]
    private Text answerDText;

    [SerializeField]
    private Text answerDResponse;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Text statusText;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private float timeBetweenQuestions = 1f;

    public static void ResetGame()
    {
        questions = null;
        unansweredQuestions = null;
        score = 0;
    }

    void Start()
    {
        if (!string.IsNullOrEmpty(quizFile))
        {
            LoadQuestions();
        }
    }

    void LoadQuestions()
    {
        if (unansweredQuestions !=  null && unansweredQuestions.Count == 0)
        {
            SceneManager.LoadScene("Outro");
            return;
        }
        else if (unansweredQuestions == null)
        {
            string[] questionLines = File.ReadAllLines(quizFile);

            questions = new Question[questionLines.Length];

            for (int i = 0; i < questions.Length; i++)
            {
                string[] questionLineParts = questionLines[i].Split('|');

                questions[i] = new Question();

                questions[i].questionText = questionLineParts[0];
                questions[i].answerAText = questionLineParts[1];
                questions[i].answerBText = questionLineParts[2];
                questions[i].answerCText = questionLineParts[3];
                questions[i].answerDText = questionLineParts[4];
                questions[i].correctAnswer = questionLineParts[5].ToCharArray()[0];
            }

            unansweredQuestions = questions.ToList<Question>();

            updateScore(0, true);
        }
        else
        {
            updateScore(0);
            updateStatus();
        }
        SetCurrentQuestion();
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = UnityEngine.Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        questionText.text = currentQuestion.questionText;

        answerAText.text = currentQuestion.answerAText;
        answerBText.text = currentQuestion.answerBText;
        answerCText.text = currentQuestion.answerCText;
        answerDText.text = currentQuestion.answerDText;
    }

    IEnumerator TransitionToNextQuestion()
    {
        yield return new WaitForSeconds(timeBetweenQuestions);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void updateScore(int scoreChange = 0, bool reset = false)
    {
        if (reset)
            score = 0;

        score += scoreChange;

        if (questions.Length - unansweredQuestions.Count() > 0)
        {
            scoreText.text = "Percent Correct: " + Math.Round(((double)score / ((double)questions.Length - (double)unansweredQuestions.Count())) * 100.0, 1) + "%";
        }
        else
        {
            scoreText.text = "Percent Correct: 100%";
        }
    }

    private void updateStatus()
    {
        statusText.text = "Question " + (questions.Length - unansweredQuestions.Count() + 1) + " of " + questions.Length;
    }

    public void userSelectA()
    {
        unansweredQuestions.Remove(currentQuestion);

        if (char.ToUpper(currentQuestion.correctAnswer) == 'A')
        {
            updateScore(1);
            answerAResponse.text = "CORRECT";
            animator.SetTrigger("correctA");
        }
        else
        {
            updateScore(0);
            answerAResponse.text = "WRONG";
            animator.SetTrigger("incorrectA");
        }

        StartCoroutine(TransitionToNextQuestion());
    }

    public void userSelectB()
    {
        unansweredQuestions.Remove(currentQuestion);
        if (char.ToUpper(currentQuestion.correctAnswer) == 'B')
        {
            updateScore(1);
            answerBResponse.text = "CORRECT";
            animator.SetTrigger("correctB");
        }
        else
        {
            updateScore(0);
            answerBResponse.text = "WRONG";
            animator.SetTrigger("incorrectB");
        }

        StartCoroutine(TransitionToNextQuestion());
    }

    public void userSelectC()
    {
        unansweredQuestions.Remove(currentQuestion);
        if (char.ToUpper(currentQuestion.correctAnswer) == 'C')
        {
            updateScore(1);
            answerCResponse.text = "CORRECT";
            animator.SetTrigger("correctC");
        }
        else
        {
            updateScore(0);
            answerCResponse.text = "WRONG";
            animator.SetTrigger("incorrectC");
        }

        StartCoroutine(TransitionToNextQuestion());
    }

    public void userSelectD()
    {
        unansweredQuestions.Remove(currentQuestion);
        if (char.ToUpper(currentQuestion.correctAnswer) == 'D')
        {
            updateScore(1);
            answerDResponse.text = "CORRECT";
            animator.SetTrigger("correctD");
        }
        else
        {
            updateScore(0);
            answerDResponse.text = "WRONG";
            animator.SetTrigger("incorrectD");
        }

        StartCoroutine(TransitionToNextQuestion());
    }
}
