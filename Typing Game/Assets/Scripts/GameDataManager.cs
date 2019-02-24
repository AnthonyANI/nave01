using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDataManager : MonoBehaviour {
    public static float AccuracyDecimalPercentage { get; set; }
    public static int Score { get; set; }
    public static float SpeedDecimalPercentage { get; set; }
    public static string WordsFile { get; set; }
    public static float WordsPerMinute { get; set; }

    public Text AccuracyTextDisplay;
    public Text ScoreTextDisplay;
    public Text SpeedTextDisplay;
    public Text WpmTextDisplay;
    	
	// Update is called once per frame
	void Update ()
    {
        updateAccuracyTextDisplay();
        updateScoreTextDisplay();
        updateSpeedTextDisplay();
        updateWordsPerMinuteTextDisplay();
    }

    private void updateAccuracyTextDisplay ()
    {
        if (AccuracyTextDisplay != null)
            AccuracyTextDisplay.text = "Accuracy: " + Math.Round(AccuracyDecimalPercentage * 100.0f, 1).ToString("0.0") + "%";
    }

    private void updateScoreTextDisplay ()
    {
        if (ScoreTextDisplay != null)
            ScoreTextDisplay.text = "Score: " + Score;
    }

    private void updateSpeedTextDisplay ()
    {
        if (SpeedTextDisplay != null)
            SpeedTextDisplay.text = "Speed: " + Math.Round(SpeedDecimalPercentage * 100.0f, 1) + "%";
    }

    private void updateWordsPerMinuteTextDisplay()
    {
        if (Time.time > 0 && SceneManager.GetActiveScene().name == "Main")
        {
            WordsPerMinute = (float)Math.Round(Score / (Time.time / 60f), 1);
        }

        if (WpmTextDisplay != null)
            WpmTextDisplay.text = "Words Per Minute: " + WordsPerMinute.ToString("0.0");
    }

    public static void Reset ()
    {
        AccuracyDecimalPercentage = 1f;
        Score = 0;
        SpeedDecimalPercentage = 0f;
        WordsFile = "";
        WordsPerMinute = 0f;
    }
}
