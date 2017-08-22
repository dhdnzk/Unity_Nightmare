using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    void Start ()
    {
//        InvokeRepeating ("Spawn", spawnTime, spawnTime);

		StartCoroutine (Spawn ());
    }


//    void Spawn ()
//    {
//        if(playerHealth.currentHealth <= 0f)
//        {
//            return;
//        }
//
//        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
//
//        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
//
//    }

	IEnumerator Spawn ()
    {
		while (true) {

			if (playerHealth.currentHealth <= 0f) {

				yield return null;

			}

			int spawnPointIndex = Random.Range (0, spawnPoints.Length);

			Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);

			yield return new WaitForSeconds (spawnTime);
		}
    }

}
