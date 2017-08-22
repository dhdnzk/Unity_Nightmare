using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float defaultCameraSize;
	public float zoomOuttedCameraSize;

	private Camera mainCamera;
	private float smoothing;
	private Vector3 offset;

	void Start() {

		mainCamera = GetComponent <Camera> ();
		offset = this.GetComponent <Transform>().position - target.position;
		smoothing = 5f * Time.deltaTime;

	}

	void Update() {

		if (Input.GetMouseButton (1)) {

			mainCamera.orthographicSize = zoomOuttedCameraSize;

		} else {

			mainCamera.orthographicSize = defaultCameraSize;

		}

	}

	void FixedUpdate() {
		
		Vector3 curCamPosition = this.GetComponent <Transform> ().position;
		
		Vector3 newCamPosition = (target.position + offset);

		this.GetComponent <Transform>().position = Vector3.Lerp (curCamPosition, newCamPosition, smoothing);

	}
}
