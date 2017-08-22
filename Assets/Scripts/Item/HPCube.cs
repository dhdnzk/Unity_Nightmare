using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPCube : MonoBehaviour {

	public int healAmount;

	GameObject player;

	PlayerHealth playerHealth;

	bool isSpawned;


	void Awake() {

		player = GameObject.FindGameObjectWithTag ("Player");

		playerHealth = player.GetComponent <PlayerHealth> ();

		isSpawned = GameObject.FindGameObjectWithTag ("CubeManager").GetComponent <HPCubeManager> ().isSpawned;

	}

	void Start() {


	}

	void FixedUpdate() {

		transform.Rotate (new Vector3(1f, 1f, 1f));

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == player && playerHealth.currentHealth < playerHealth.startingHealth) {

			playerHealth.GetHP (healAmount);

			if (playerHealth.currentHealth > playerHealth.startingHealth) {

				playerHealth.currentHealth = playerHealth.startingHealth;

			}

			Destroy (this.gameObject);

			isSpawned = !isSpawned;


		}

	}

}
