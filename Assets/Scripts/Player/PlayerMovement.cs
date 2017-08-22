using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float playerSpeed;

	Animator anim;
	Rigidbody playerRigidbody;

	float camRayLength;		//카메라에서 발사하는 광선의 길이(레이캐스트)
	int floorMask;			//quad와 카메라 레이캐스트의 충돌만 판정할 것이므로 quad의 레이어마스크 정보를 참조할때 쓴다.

	void Awake() {
		
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
		camRayLength = 100f;
		floorMask = LayerMask.GetMask ("Floor");
	}

	void FixedUpdate() {

		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		WalkingProcess (h, v);
	
	}

	void WalkingProcess(float h, float v) {

		Animating (h, v);
		Move (h, v);
		Turn ();

	}

	void Move(float h, float v) {

		Vector3 movement = new Vector3 (h, 0f, v).normalized * playerSpeed * Time.deltaTime;
		playerRigidbody.MovePosition (transform.position + movement);

	}
		
	void Turn() {

		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit floorHit;

		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {

			Vector3 playerToMouse = floorHit.point - transform.position;

			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);

			playerRigidbody.MoveRotation (newRotation);

		}

	}

	void Animating(float h, float v) {

		bool isMoving = (h != 0f || v != 0f);

		anim.SetBool ("IsMoving", isMoving);
	
	}

}
