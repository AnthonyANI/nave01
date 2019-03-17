using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroController : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene("NavMeshGameIntro");
    }
}
