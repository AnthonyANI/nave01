using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    private float timer = 30f;

    public Text timerText;

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timerText)
                timerText.text = ((int)timer).ToString();
        }
        else
        {
            SceneManager.LoadScene("Outro");
        }
    }
}
