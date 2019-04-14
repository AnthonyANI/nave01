using UnityEngine;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour {

	public Rigidbody2D rb;

    private Vector2 spawnPos;
    private float frogScale = 1f;

    void Start()
    {
        ResizeFrog();
        spawnPos = rb.position;
    }

	void Update () {

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Vector2 newPos = rb.position + new Vector2(frogScale, 0f);
            if (!(1.0 < Camera.main.WorldToViewportPoint(new Vector3(newPos.x, newPos.y)).x)) {
                rb.MovePosition(newPos);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 270f);
                Score.UpdateHops();
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Vector2 newPos = rb.position + new Vector2(-frogScale, 0f);
            if (!(Camera.main.WorldToViewportPoint(new Vector3(newPos.x, newPos.y)).x < 0.0))
            {
                rb.MovePosition(newPos);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90f);
                Score.UpdateHops();
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Vector2 newPos = rb.position + new Vector2(0f, frogScale);
            if (!(1.0 < Camera.main.WorldToViewportPoint(new Vector3(newPos.x, newPos.y)).y))
            {
                rb.MovePosition(newPos);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
                Score.UpdateHops();
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            Vector2 newPos = rb.position + new Vector2(0f, -frogScale);
            if (!(Camera.main.WorldToViewportPoint(new Vector3(newPos.x, newPos.y)).y < 0.0))
            {
                rb.MovePosition(newPos);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 180f);
                Score.UpdateHops();
            }
        }

	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Car")
		{
			Score.UpdateFails();
			ResetPosition();
		}
	}

    void ResizeFrog()
    {
        frogScale = (float)GameDataManager.frogSize * .5f;
        transform.localScale = new Vector3(frogScale, frogScale, 1f);
    }

    public void ResetPosition()
    {
        rb.MovePosition(spawnPos);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
    }
}
