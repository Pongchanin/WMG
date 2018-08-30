using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour {

	public GameObject enemy;
	float randX;
	Vector2 WhereToSpawn;
	public float spawnRate = 2f;
	float nextSpawn = 0.0f;

	void Start () {
		
	}
	

	void Update () 
	{
		if (Time.time > nextSpawn) 
		{
			nextSpawn = Time.time + spawnRate;
			randX = Random.Range (0f, 100f);
			WhereToSpawn = new Vector2 (randX, transform.position.y);
			Instantiate (enemy, WhereToSpawn, Quaternion.identity);
		}
	}
}
