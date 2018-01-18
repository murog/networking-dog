using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkingDog {
	[RequireComponent(typeof(Rigidbody))]
public class MoveGround : MonoBehaviour {
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
			rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
//			Physics.IgnoreCollision(other.GetComponent<Collider>(), GetComponent<Collider>());
			rb.velocity = new Vector3 (0, 0, GroundScroll.ground_speed);
//			print ("the updated position is");
//			print (transform.position);
//			print ("the updated rotation is");
//			print (transform.rotation);
	}
		void OnCollisionEnter (Collision other) {
		print ("secretly colliding rn");
		print (other.gameObject.name);
			if (other.gameObject.tag != "garbage") {
//				Physics.IgnoreCollision (other.GetComponent<Collider> (), GetComponent<Collider> (), true);
				Physics.IgnoreCollision(other.collider, GetComponent<Collider>());
				print ("the other is");
				print(other);
			} else {
				print ("lol i'm in here");
			}
		if (other.gameObject.tag == "garbage") {
//			spawnable = true;
		}
	}


	
//	void onCollisionStay (Collider  other) {
//		if (transform.position.z < -30) {
//				
//		}
//	}
}
}
