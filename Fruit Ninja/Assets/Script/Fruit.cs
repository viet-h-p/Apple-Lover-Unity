using UnityEngine;
using UnityEngine.UI;

public class Fruit : MonoBehaviour 
{
	private const float GRAVITY = 2.0f;
	public bool IsActive {set; get;}

	private float verticalVelocity;
	private float speed;
	private bool isSliced = false;
	public SpriteRenderer spriteRenderer;

	public Sprite[] sprites;
	private int spriteIndex;
	private float lastSpriteUpdate;
	private float spriteUpdateDelta = 0.2f;

	public void LaunchFruit(float verticalVelocity, float xSpeed, float xStart)
	{
		IsActive = true;
		speed = xSpeed;
		this.verticalVelocity = verticalVelocity;
		transform.position = new Vector3(xStart, 0, 0);
		isSliced = false;
		spriteIndex = 0;
		spriteRenderer.sprite = sprites[spriteIndex];
	}

	private void Update()
	{
		if (!IsActive) return;

		verticalVelocity -= GRAVITY * Time.deltaTime;
		transform.position += new Vector3(speed, verticalVelocity, 0) * Time.deltaTime;

		if (isSliced)
		{
			if ((spriteIndex != (sprites.Length - 1)) && ((Time.time - lastSpriteUpdate) > spriteUpdateDelta))
			{
				lastSpriteUpdate = Time.time;
				spriteIndex++;
				spriteRenderer.sprite = sprites[spriteIndex];
			}
		}

		if (transform.position.y < -1)
		{
			IsActive = false; 
			if (!isSliced)
				GameManager.Instance.LoseLifepoint();
		}
	}

	public void Slice()
	{
		if (isSliced) return;
		
		if (verticalVelocity < 0.5f)
			verticalVelocity = 0.5f;

		speed *= 0.5f;
		isSliced = true;

		GameManager.Instance.IncrementScore(1);
	}

}
