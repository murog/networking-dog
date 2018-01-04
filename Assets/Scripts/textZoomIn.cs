using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textZoomIn : MonoBehaviour {
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.z > 4) {
			rb.velocity = new Vector3 (0, 0, -1);
		} else {
			transform.Rotate (3, 0, 0);
		}
	}
}
