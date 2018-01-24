using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NetworkingDog {
public class textZoomIn : MonoBehaviour {
	public Rigidbody rb;
//	public GUIText kloutText;
	public KeyCode restart;
	private string count;
	
//	private GameObject[] trueConnections;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		if (GM.kloutCount > 0) {
			count = GM.kloutCount.ToString ();
		} else {
			count = "really 0...you got to get urself out there";
		}
//		kloutText.text = count;
		print (count);
		print (GM.kloutCount);
//		print (trulyMoveOrb.connections.Count);
		print ("trying to find connections");

//			for (int i = 0; i < GM.connections.Count ; i++) {
//			print ("trying to instantiate");
//			var position = new Vector3 (5 * i, 0, 0);
//			Instantiate (trulyMoveOrb.connections [i], position, Quaternion.identity);
//		}
			foreach (string name in GM.connections.Keys) {
				print (name);
				print (GM.connections [name]);
				GameObject person = Prefabs.ReturnPositive (name) as GameObject; 
				for (int i = 1; i <= GM.connections [name]; i++) {
					var position = new Vector3 (0, 0, 0);
					Instantiate (person, position, Quaternion.identity);
				}
			}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.z > 4) {
			rb.velocity = new Vector3 (0, 0, -1);
		} else {
			transform.Rotate (3, 0, 0);
		}
		if (Input.GetKeyDown(restart)) {
			SceneManager.LoadScene ("Sidewalk");
		} 

	}
}
}