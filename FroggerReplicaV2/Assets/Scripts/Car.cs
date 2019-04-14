using UnityEngine;

public class Car : MonoBehaviour {

	public Rigidbody2D rb;

	public float minSpeed = 8f;
	public float maxSpeed = 12f;

	float speed = 1f;

	void Start ()
	{
        UpdateCarSpeed();
		speed = Random.Range(minSpeed + Score.WinCount, maxSpeed + Score.WinCount);
	}

    void FixedUpdate () {
		Vector2 forward = new Vector2(transform.right.x, transform.right.y);
		rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
	}

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Road")
            Destroy(gameObject);
    }

    private void UpdateCarSpeed()
    {
        minSpeed = 4f * GameDataManager.initialCarSpeed;
        maxSpeed = 6f * GameDataManager.initialCarSpeed;
    }

}
