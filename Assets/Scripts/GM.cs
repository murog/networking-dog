using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NetworkingDog {
	
public class GM : MonoBehaviour {

	public static float vertVel = 0;
	public static int kloutCount = 0;
	public static int timeCount;
	public Transform dawg;
	private Animator animator;
	public static Dictionary<string, int> connections = new Dictionary<string, int> ();


	// Use this for initialization
	void Start () {
//		animator = dawg.GetComponent<Animator> ();	
	}
	
	// Update is called once per frame
	void Update () {
			if (trulyMoveOrb.positiveCollision) {
//				animator.SetBool("bark", true);
				print ("tried to bark rn");
				trulyMoveOrb.positiveCollision = false;
			}
	}

	public static void Network(string name) {
			if (!connections.ContainsKey (name)) {
				connections[name] = 1;
			} else {
				connections[name] = connections[name] + 1;
			}
	}
	}
}
