using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroManager : MonoBehaviour
{
    void Start()
    {
        if (Score.WinCount > 1)
        {
            GameDataManager.highScores.Add(new KeyValuePair<string, int>(GameDataManager.currentPlayerName, Score.WinCount));
            GameDataManager.SaveHighScores();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Intro");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
