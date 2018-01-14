using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkingDog {
public class Prefabs : MonoBehaviour {
	private Object[] props;


	// Use this for initialization
	void Start () {
			props = Resources.LoadAll("PROPS_ENVIRONMENT", typeof(GameObject)) as Object[];
			foreach (var item in props) {
				print (item);
			}
			print (props);


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
}