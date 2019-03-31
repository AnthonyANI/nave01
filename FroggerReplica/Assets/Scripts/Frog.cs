using UnityEngine;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour {

	public Rigidbody2D rb;

    private Vector2 spawnPos;

    void Start()
    {
        spawnPos = rb.position;
    }

	void Update () {

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Vector2 newPos = rb.position + Vector2.right;
            if (!(1.0 < Camera.main.WorldToViewportPoint(new Vector3(newPos.x, newPos.y)).x)) {
                rb.MovePosition(newPos);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 270);
                Score.updateHops();
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Vector2 newPos = rb.position + Vector2.left;
            if (!(Camera.main.WorldToViewportPoint(new Vector3(newPos.x, newPos.y)).x < 0.0))
            {
                rb.MovePosition(newPos);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90);
                Score.updateHops();
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Vector2 newPos = rb.position + Vector2.up;
            if (!(1.0 < Camera.main.WorldToViewportPoint(new Vector3(newPos.x, newPos.y)).y))
            {
                rb.MovePosition(newPos);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
                Score.updateHops();
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            Vector2 newPos = rb.position + Vector2.down;
            if (!(Camera.main.WorldToViewportPoint(new Vector3(newPos.x, newPos.y)).y < 0.0))
            {
                rb.MovePosition(newPos);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 180);
                Score.updateHops();
            }
        }

	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Car")
		{
			Score.updateFails();
			ResetPosition();
		}
	}

    public void ResetPosition()
    {
        rb.MovePosition(spawnPos);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }
}
