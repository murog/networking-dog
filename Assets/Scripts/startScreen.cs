using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScreen : MonoBehaviour {
	public float horizontalSpeed = 2.0F;
	public float verticalSpeed = 2.0F;
	private bool gameStart;
	private Rigidbody rb;
	private float h;
	Quaternion originalRotation;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		originalRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update() {
		if (!gameStart) {
			h = horizontalSpeed * Input.GetAxis ("Mouse X");
//		float v = verticalSpeed * Input.GetAxis("Mouse Y");
			transform.Rotate (0, h, 0);
		}
		if (Input.GetMouseButtonDown (0)) {
			gameStart = true;
			transform.Rotate (0, -h, 0);
		}
		if (gameStart) {
			rb.velocity = new Vector3 (0, 0, 1);
		}
	}
}
