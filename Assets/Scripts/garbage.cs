using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkingDog {
	
public class garbage : MonoBehaviour {
		[SerializeField]
		private Rigidbody rb;
	// Use this for initialization
	void Start () {
			rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
			rb.velocity = new Vector3 (0, 0, 0.5f);
	}

	void OnTriggerEnter(Collider other) {
			Destroy(other.gameObject);
	}
	}
}
