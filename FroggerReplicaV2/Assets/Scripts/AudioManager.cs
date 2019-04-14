using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource gameMusic;

    // Start is called before the first frame update
    void Start()
    {
        if (gameMusic && GameDataManager.musicEnabled)
        {
            gameMusic.Play();
        }
    }

}