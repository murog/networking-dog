using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (gameObject.name == "kloutText") {
			GetComponent<TextMesh> ().text = GM.kloutCount + " klout";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
