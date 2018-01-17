using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkingDog {
	[RequireComponent(typeof(Rigidbody))]
public class MoveGround : MonoBehaviour {
	public static bool spawnable = true;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
			rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
//			Physics.IgnoreCollision(other.GetComponent<Collider>(), GetComponent<Collider>());
			rb.velocity = new Vector3 (0, 0, -2);
			print ("the updated position is");
			print (transform.position);
	}
	void OnCollisionEnter (Collision other) {
		print ("secretly colliding rn");
		print (other.gameObject.name);
			if (other.gameObject.tag != "garbage") {
				Physics.IgnoreCollision (other.GetComponent<Collider> (), GetComponent<Collider> (), true);
			} else {
				print ("lol i'm in here");
			}
		if (other.gameObject.tag == "garbage") {
			spawnable = true;
		}
	}


	
//	void onCollisionStay (Collider  other) {
//		if (transform.position.z < -30) {
//				
//		}
//	}
}
}
