using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class networkingOpportunities : MonoBehaviour {
	public float speed;
	public Rigidbody rb;
	private bool collided = false;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame

	void Update() {
		if (!collided) {
//			rb.velocity = new Vector3 (0, 0, -1);
		} else {
			rb.velocity = Vector3.zero;
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player") {
			collided = true;
		} else {
			Physics.IgnoreCollision(other.collider, GetComponent<Collider>());
		}
	}
}
