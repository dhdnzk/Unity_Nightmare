using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
	public int startingHealth = 100;
	public int currentHealth = 0;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
	Canvas healthCanvas;
	Slider healthSlider;
    bool isDead;
    bool isSinking;


    void Awake ()
    {

        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();
		healthCanvas = GetComponentInChildren  <Canvas>();
		healthSlider = GetComponentInChildren <Slider> ();

		isSinking = false;
		isDead = false;

    }

	void Start() {

		currentHealth = startingHealth;
		healthSlider.maxValue = startingHealth; 
		healthSlider.minValue = 0f;
		healthSlider.value = currentHealth;

	}


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }

		healthCanvas.transform.rotation = Quaternion.LookRotation (new Vector3(0f, 0f, 0f));

    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;

		healthSlider.value = currentHealth;

        hitParticles.transform.position = hitPoint;

        hitParticles.Play();

        if(currentHealth <= 0)
        {

            Death ();
		/* StartSinking ();  어디서 호출하는거지? */

        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

		healthCanvas.enabled = false;

        anim.SetTrigger ("Die");

        enemyAudio.clip = deathClip;

        enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }
}
