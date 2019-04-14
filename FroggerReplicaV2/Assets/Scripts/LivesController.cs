using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivesController : MonoBehaviour
{
    public Image frog1;
    public Image frog2;
    public Image frog3;

    // Update is called once per frame
    void Update()
    {
        if (Score.FailCount > 3)
        {
            SceneManager.LoadScene("Outro");
        }

        switch (Score.FailCount)
        {
            case 1:
                frog1.gameObject.SetActive(true);
                frog2.gameObject.SetActive(true);
                frog3.gameObject.SetActive(false);
                break;
            case 2:
                frog1.gameObject.SetActive(true);
                frog2.gameObject.SetActive(false);
                frog3.gameObject.SetActive(false);
                break;
            case 3:
                frog1.gameObject.SetActive(false);
                frog2.gameObject.SetActive(false);
                frog3.gameObject.SetActive(false);
                break;
            case 0:
            default:
                frog1.gameObject.SetActive(true);
                frog2.gameObject.SetActive(true);
                frog3.gameObject.SetActive(true);
                break;
        }
    }
}
