using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPCubeManager : MonoBehaviour {

	public PlayerHealth playerHealth;
	public GameObject HPCube;
	public float spawnTime;
	public Transform[] spawnPoints;
	int positionIdx;

	public bool isSpawned;


	void Awake() {

		isSpawned = false;

	}


	void Start ()
	{


		StartCoroutine (Spawn ());

	}

	IEnumerator Spawn ()
	{

		yield return new WaitForSeconds (spawnTime);

		while (true) {

			if (playerHealth.currentHealth <= 0f || playerHealth.currentHealth == playerHealth.startingHealth || !isSpawned)

				yield return null;

			int spawnPointIndex = Random.Range (0, spawnPoints.Length);

			Instantiate (HPCube, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);

			isSpawned = true;

			yield return new WaitForSeconds (spawnTime);

		}


	}

}

