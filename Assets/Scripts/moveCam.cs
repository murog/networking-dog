using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace NetworkingDog {
public class moveCam : MonoBehaviour {
	public GameObject networkingDog;
//	public Transform player;
	private Vector3 offset;
	private Quaternion startRotation;
	private Quaternion endRotation;
	private bool doPanning = false;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private float startFOV;
	private float zoomInFOV;
	private bool doZoom = false;
	private Rigidbody rb;
	private bool doRotate = false;
	public Transform pug;
	private bool doMove = false;
	private Rigidbody rb_pug;
	// Use this for initialization
	void Start () {
		networkingDog = GameObject.Find("networkingDog");
		if (!networkingDog) {
			print ("no dog here lol");
		}
		offset = transform.position - networkingDog.transform.position;
		print (offset);
		rb = GetComponent<Rigidbody> ();	
		startRotation = transform.rotation;

	}
	
	// Update is called once per frame
	void LateUpdate () {
			if (!trulyMoveOrb.gameEnd && !doRotate) {
				transform.position = networkingDog.transform.position + offset;
			}
			if (trulyMoveOrb.gameEnd) {
//				transform.DetachChildren ();
				if (!doMove) {
					rb_pug = pug.gameObject.AddComponent (typeof(Rigidbody)) as Rigidbody;
					rb_pug.useGravity = false;
					doMove = true;
					transform.DetachChildren ();
				}

//				startPosition = transform.position;
//				endPosition = new Vector3 (4, startPosition.y, startPosition.z);
				if (pug.transform.position.z < 6.8 && !doRotate) {
					rb_pug.velocity = new Vector3 (0, 0, 1);
				} else if (!doRotate) {
//					doRotate = true;
					rb_pug.velocity = new Vector3 (0, 0, 0);
					startRotation = pug.transform.rotation;
					endRotation =	new Quaternion (0, 0, 0, 0);
					doZoom = true;
					startFOV = Camera.main.fieldOfView;
					zoomInFOV = 30;
				}

				if (doRotate) {
					pug.transform.rotation = Quaternion.Slerp (startRotation, endRotation, Time.deltaTime * 2);
					print ("*****************rotating*****************");
					print ("the velocity is " + rb.velocity.ToString());
					print ("the start rotation is " + startRotation.ToString ());
					print ("the end rotation is " + endRotation.ToString ());
					print ("the current rotation is " + transform.rotation);
					if (transform.rotation == new Quaternion (0, -1.0f, 0, 0)) {
						doRotate = false;
						startFOV = Camera.main.fieldOfView;
						zoomInFOV = 30;
						doZoom = true;
					}
				}
				if (doZoom) {
					Camera.main.fieldOfView = Mathf.Lerp(startFOV, zoomInFOV, Time.deltaTime * 2);
					if (Camera.main.fieldOfView < 30.5f) {
						doZoom = false;
						SceneManager.LoadScene ("LevelComplete");
					}
				}

			//		if (waitToLoad > 5) {
			//			SceneManager.LoadScene ("Sidewalk");
			//		}

//				float startFOV = Camera.main.fieldOfView;
//				float zoomInFOV = 30;
//				Camera.main.fieldOfView = Mathf.Lerp(startFOV, zoomInFOV, Time.deltaTime * 2);
//				print (Camera.main.fieldOfView);
//				if (Camera.main.fieldOfView < 30.5f) {
//					doZoom = true;
//				}

//			if (doPanning) {
////				transform.rotation = Quaternion.Slerp (startRotation, endRotation, Time.deltaTime * 2);
////				transform.position = Vector3.Lerp(startPosition, endPosition, Time.deltaTime * 2);
//				rb.velocity = new Vector3 (5, 0, 0);
//				print (transform.rotation);
//					if ((transform.rotation == new Quaternion(0, -1.0f, 0, 0)) && transform.position.z > 3.8) {
//					doPanning = false;
//					rb.velocity = new Vector3 (0, 0, 0);
//					print ("do panning is" + doPanning.ToString ());
//					SceneManager.LoadScene ("LevelComplete");
//
//					//				startRotation = transform.rotation;
//					//				endRotation = 
//				}
//			}
			}
		
	}
//		IEnumerator RotateCamera() {
//			
//		}
}
}