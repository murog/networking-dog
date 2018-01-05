using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class startScreen : MonoBehaviour {
	public float horizontalSpeed = 2.0F;
	public float verticalSpeed = 2.0F;
	public float resetSpeed = 0.5F;
	public float cameraSpeed = 1.5F;
	private bool gameStart;
	private Rigidbody rb;
	private float h;
	private float v;
	Quaternion originalRotation;
	private bool restoreRotation = false;
	private float waitToLoad;
	public GUIText countDown;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		originalRotation = transform.rotation;
		countDown = GetComponent<GUIText> ();
	}
	
	// Update is called once per frame
	void Update() {
		// allow for horizontal mouse movement
		if (!restoreRotation) {
			h = horizontalSpeed * Input.GetAxis ("Mouse X");
			v = verticalSpeed * Input.GetAxis ("Mouse Y");
			transform.Rotate (v, h, 0);
		}
		if (Input.GetMouseButtonDown (0)) {
			gameStart = true;
			restoreRotation = true;
//			transform.Rotate (0, -h, 0);
		}
		if (restoreRotation) {
			transform.rotation = Quaternion.Lerp(transform.rotation,originalRotation,Time.time * resetSpeed);
		}
		if (transform.rotation == originalRotation) {
			restoreRotation = false;
		}
		if ((gameStart) && (transform.position.z < 25)) {
			rb.velocity = (new Vector3 (0, 0, 1)) * cameraSpeed;
		}
		if (transform.position.z >= 25) {
			rb.velocity = new Vector3 (0, 0, 0);
			waitToLoad += Time.deltaTime;
		}
		if (waitToLoad > 0) {
			countDown.text = "get ready";
		}

		if (waitToLoad > 2) {
			SceneManager.LoadScene ("Sidewalk");
		}
	}
}
