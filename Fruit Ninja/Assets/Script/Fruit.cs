using UnityEngine;

public class Fruit : MonoBehaviour 
{
	private const float GRAVITY = 2.0f;
	public bool IsActive {set; get;}

	private float verticalVelocity;
	private float speed;

	private void Start()
	{
		LaunchFruit(2.0f, 1, -1);
	}

	public void LaunchFruit(float verticalVelocity, float xSpeed, float xStart)
	{
		IsActive = true;
		speed = xSpeed;
		this.verticalVelocity = verticalVelocity;
		transform.position = new Vector3(xStart, 0, 0);
	}

	private void Update()
	{
		if (!IsActive) return;

		verticalVelocity -= GRAVITY * Time.deltaTime;
		transform.position += new Vector3(speed, verticalVelocity, 0) * Time.deltaTime;

		if (transform.position.y < -1)
			IsActive = false; 
	}

	public void Slice()
	{
		if (verticalVelocity < 0.5f)
			verticalVelocity = 0.5f;

		speed *= 0.5f;
	}

}
