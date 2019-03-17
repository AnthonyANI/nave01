using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public NavMeshGameController gameController;

    // Update is called once per frame
    void Update()
    {
        if (gameController.timer > 0)
        {
            gameController.timer -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("NavMeshGameOutro");
        }
    }
}
