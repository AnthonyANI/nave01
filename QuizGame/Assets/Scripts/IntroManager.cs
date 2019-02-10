using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class IntroManager : MonoBehaviour {
    void Start()
    {

    }

    public void userSelectStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void userSelectQuit()
    {
        Application.Quit();
    }
}
