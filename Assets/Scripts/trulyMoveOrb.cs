using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //do i need this if i have line 3

namespace NetworkingDog {
	
public class trulyMoveOrb : Singleton<trulyMoveOrb> {
	public KeyCode moveL;
	public KeyCode moveR;
	public float horizVel = 0;
	public float laneNum = 2.0f;
	public bool controlBlocked = false;
	private float waitToLoad;
	private string status;
	public float zScenePos;
	public Transform path;
	public static float playerPosition;
	// Use this for initialization
	void Start () {
//		print ("i'm starting haha");

	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity = new Vector3 (horizVel, 0, 4);
		if ((Input.GetKeyDown (moveL)) && (laneNum > 1) && (!controlBlocked)) {
			horizVel = -1;
			StartCoroutine (stopSlide ());
			laneNum -= 0.5f;
			controlBlocked = true;
			print ("left!");
		} else if ((Input.GetKeyDown (moveR)) && (laneNum < 4) && (!controlBlocked)) {
			horizVel = 1;
			StartCoroutine (stopSlide ());
			laneNum += 0.5f;
			controlBlocked = true;
			print ("right!");
		} else {
//			horizVel = 0;
			print ("else!!");
		}
		if (status == "exit") {
			waitToLoad += Time.deltaTime;
		}
		if (waitToLoad > 0.5) {
			SceneManager.LoadScene ("LevelComplete");
		} 
		print (controlBlocked);
		playerPosition = transform.position.z;
			
	}

	void OnCollisionEnter(Collision other)
	{	
			if (other.gameObject.tag == "lethal") {
				print ("this is lethal");
				print (other.gameObject);
				Destroy (gameObject);
			} else if (other.gameObject.tag == "klout") {
				GM.kloutCount += 1;
			} else if (other.gameObject.tag == "exit") {
				print ("this is the exit huh");
				status = "exit";
			} else if (other.gameObject.tag == "sidewalk") {
				Physics.IgnoreCollision(other.collider, GetComponent<Collider>());
			}
	}

	void OnCollisionStay(Collision other) {
		if (other.gameObject.tag == "klout") {
			GM.kloutCount += 1;
//			print (GM.kloutCount);
		} 
	}
			

	IEnumerator stopSlide ()
	{
		yield return new WaitForSeconds(0.3f);
		horizVel = 0;
		controlBlocked = false;
//		return;
	}
}
}
