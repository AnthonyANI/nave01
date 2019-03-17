using UnityEngine;
using UnityEngine.UI;

public class NavMeshGameController : MonoBehaviour
{
    public static int score { get; set; }
    public float timer = 30f;

    public Text ScoreText;
    public Text TimeText;
    

    // Update is called once per frame
    void Update()
    {
        if (ScoreText)
            ScoreText.text = "Score: " + score;

        if (TimeText)
            TimeText.text = "Time Left: " + (int)timer;
    }
}
