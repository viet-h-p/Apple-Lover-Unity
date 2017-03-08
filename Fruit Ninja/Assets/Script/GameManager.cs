using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	private const float REQUIRED_SLICEFORCE = 400.0f;

	private List<Fruit> fruit = new List<Fruit>();
	public GameObject fruitPrefab;

	private float lastSpawn;
	private float deltaSpawn = 1.0f;

	public Transform trail;

	private Vector3 lastMousePos;
	private Collider2D[] fruitCols = new Collider2D[0];

	private void Start()
	{
		
	}

	private Fruit GetFruit()
	{
		Fruit f = fruit.Find(x => !x.IsActive); // find the false IsActive fruit

		if (f == null)
		{
			f = Instantiate(fruitPrefab).GetComponent<Fruit>();
			fruit.Add(f);
		}

		return f;
	}
	
	private void Update () 
	{
		if (Time.time - lastSpawn > deltaSpawn)
		{
			Fruit f = GetFruit();
			float randomX = Random.Range(-1.65f, 1.65f);

			f.LaunchFruit(Random.Range(1.85f, 2.75f), randomX, -randomX);
			// A fruit is randomly spawn on the left or right or the middle of the screen
			// if left throw to the right, right throw to the left, and middle straight up  

			lastSpawn = Time.time;
		}	

		if (Input.GetMouseButton(0))
		{
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //return a vector3
			pos.z = -1;
			trail.position = pos;

			Collider2D[] thisFramesFruit = Physics2D.OverlapPointAll(new Vector2(pos.x, pos.y), LayerMask.GetMask("Fruit"));
			
			if((Input.mousePosition - lastMousePos).sqrMagnitude > REQUIRED_SLICEFORCE)
			{
				foreach (Collider2D c2 in thisFramesFruit)
				{
					for (int i = 0; i < fruitCols.Length; i++)
					{
						if (c2 == fruitCols[i])
						{
							c2.GetComponent<Fruit>().Slice();
						}
					}
				}
			}
			lastMousePos = Input.mousePosition;
			fruitCols = thisFramesFruit;
		}
	}
}
