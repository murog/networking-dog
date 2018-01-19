using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkingDog {
	
public class garbage : MonoBehaviour {
	public static bool spawnable = false;

//		[SerializeField]
//		private Rigidbody rb;
//		private static bool spawnable = true;
	// Use this for initialization
	void Start () {
//			rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
//			rb.velocity = new Vector3 (0, 0, 0.5f);
	}

	void OnTriggerExit(Collider other) {
			if (other.gameObject.tag == "sidewalk") {
				spawnable = true;
			}
			Destroy(other.gameObject);
	}
	}
}
