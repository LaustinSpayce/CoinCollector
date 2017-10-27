using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

	public float maxSpawn = 2.0f;
	public float minSpawn = 0.1f;

	public float spawnWidth = 5.0f;
	public float spawnDepth = 5.0f;

	public GameObject[] spawnObjects;

	private float timeSinceSpawn = 0.0f;
	private float currentSpawnTime = 0.0f;
	private Transform currentPosition;

	// Use this for initialization
	void Start () {
		timeSinceSpawn = 0.0f;
		currentSpawnTime = Random.Range(minSpawn,maxSpawn);
		currentPosition = this.gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceSpawn += Time.deltaTime;
		if (timeSinceSpawn >= currentSpawnTime) {
			spawnCoin();
		}
		
	}

	void spawnCoin () {
		timeSinceSpawn = 0.0f;
		currentSpawnTime = Random.Range(minSpawn,maxSpawn);
		GameObject objectToSpawn = spawnObjects[Random.Range (0, spawnObjects.Length)];
		Vector3 spawnPosition = new Vector3 (Random.Range(-spawnWidth, spawnWidth) + currentPosition.position.x, 
			currentPosition.position.y, Random.Range(-spawnDepth, spawnDepth) + currentPosition.position.z);
		float spawnAngle = Random.Range(0f,360f);
		Instantiate (objectToSpawn, spawnPosition, Quaternion.Euler(0, spawnAngle, 0));
	}
}
