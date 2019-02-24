using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {
    public void PlayBeginner ()
    {
        GameDataManager.WordsFile = "csharp_words_level1.txt";
        SceneManager.LoadScene("Main");
    }

    public void PlayAdvanced()
    {
        GameDataManager.WordsFile = "csharp_words_level2.txt";
        SceneManager.LoadScene("Main");
    }
}
