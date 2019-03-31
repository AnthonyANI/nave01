using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    private float timer = 30f;

    public Text TimerText;

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (TimerText)
                TimerText.text = ((int)timer).ToString();
        }
        else
        {
            SceneManager.LoadScene("Outro");
        }
    }
}
