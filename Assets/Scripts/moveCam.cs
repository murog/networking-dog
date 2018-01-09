using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCam : MonoBehaviour {
	public GameObject networkingDog;
//	public Transform player;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
//		GetComponent<Rigidbody>().velocity = new Vector3 (0, 0, 4);
		networkingDog = GameObject.Find("networkingDog");
		if (!networkingDog) {
			print ("no dog here lol");
		}
		offset = transform.position - networkingDog.transform.position;
		print (offset);
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = networkingDog.transform.position + offset;
		
	}
}
