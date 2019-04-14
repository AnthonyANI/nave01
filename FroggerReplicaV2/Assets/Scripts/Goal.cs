using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

    public Frog frog;

	void OnTriggerEnter2D ()
	{
		Score.UpdateWins();
		frog.ResetPosition();
	}

}
