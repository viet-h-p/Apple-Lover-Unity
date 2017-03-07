using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	private List<Fruit> fruit = new List<Fruit>();
	public GameObject fruitPrefab;

	private float lastSpawn;
	private float deltaSpawn = 2.0f;

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

	void Start () {
		
	}
	
	private void Update () 
	{
		if (Time.time - lastSpawn > deltaSpawn)
		{
			Fruit f = GetFruit();
			float randomX = Random.Range(-1.5f, 1.5f);

			f.LaunchFruit(Random.Range(1.5f, 3.0f), randomX, -randomX);
			// A fruit is randomly spawn on the left or right or the middle of the screen
			// if left throw to the right, right throw to the left, and middle straight up  

			lastSpawn = Time.time;
		}	
	}
}
