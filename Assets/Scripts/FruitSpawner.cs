using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

	[SerializeField] GameObject fruitPrefab;
	[SerializeField] Transform[] spawnPoints;

	[SerializeField] float minDelay = .1f;
	[SerializeField] float maxDelay = 1f;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine(SpawnFruits());
	}

	IEnumerator SpawnFruits ()
	{
		while (true)
		{
			float delay = Random.Range(minDelay, maxDelay);
			yield return new WaitForSeconds(delay);

			int spawnIndex = Random.Range(0, spawnPoints.Length);
			Transform spawnPoint = spawnPoints[spawnIndex];

			GameObject spawnedFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
			Destroy(spawnedFruit, 5f);
		}
	}
	
}
