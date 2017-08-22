using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
	public float restartDelay = 5f;

    PlayerHealth playerHealth;
    Animator anim;
	float restartTimer;

    void Awake()
    {
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent <PlayerHealth> ();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
        }

		restartTimer += Time.deltaTime;

		if(restartTimer >= restartDelay && Input.GetKey (KeyCode.Return)) {

//			SceneManager.LoadScene (0);

			SceneManager.LoadSceneAsync ("Level_01");

		}

    }
}
