using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public void StartGame()
    {
        Score.updateWins(0, true);
        Score.updateFails(0, true);
        Score.updateHops(0, true);
        SceneManager.LoadScene("Main");
    }
}
