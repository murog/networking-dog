using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textZoomIn : MonoBehaviour {
	public Rigidbody rb;
	public GUIText kloutText;
	private string count;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		if (GM.kloutCount > 0) {
			count = GM.kloutCount.ToString ();
		} else {
			count = "really 0...you got to get urself out there";
		}
		kloutText.text = count;
		print (count);
		print (GM.kloutCount);
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
