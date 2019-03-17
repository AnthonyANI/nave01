using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NavMeshGameController.score = 0;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("NavMeshGame");
    }
}
