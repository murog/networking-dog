using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace NetworkingDog {
public class moveCam : MonoBehaviour {
	private Rigidbody rb;
	public GameObject networkingDog;
	private Vector3 offset;
	private Quaternion startRotation;
	private Quaternion endRotation;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private float startFOV;
	private float zoomInFOV;
	private bool doZoom = false;
	private bool doRotate = false;
	private bool doMove = false;
	public Transform pug;
	private Rigidbody rb_pug;
	private float waittoload = 0;
	private Animator anim_pug;
	// Use this for initialization
	void Start () {
		networkingDog = GameObject.Find("networkingDog");
		if (!networkingDog) {
			print ("no dog here lol");
		}
		offset = transform.position - networkingDog.transform.position;
		print (offset);
		rb = GetComponent<Rigidbody> ();
		anim_pug = pug.GetComponent<Animator>();
//		startRotation = transform.rotation;

	}
	
	// Update is called once per frame
	void LateUpdate () {
			if (!trulyMoveOrb.gameEnd && !doRotate) {
				transform.position = networkingDog.transform.position + offset;
			}
			if (trulyMoveOrb.gameEnd) {
				if (!doMove) {
					GroundScroll.StopGround ();
					rb_pug = pug.gameObject.AddComponent (typeof(Rigidbody)) as Rigidbody;
					rb_pug.useGravity = false;
					doMove = true;
					transform.DetachChildren ();
					print ("line 45");
				}
					
				if (pug.transform.position.z < 3.8 && !doRotate) {
					
					rb_pug.velocity = new Vector3 (0, 0, 2);
					print ("line 49");
				} else if (!doRotate) {
					doRotate = true;
					rb_pug.velocity = new Vector3 (0, 0, 0);
//					startRotation = pug.transform.eulerAngles;
//					endRotation =	new Quaternion (0, 1, 0, 0);
//					endRotation = Quaternion.Euler(30, 180, 0);
					print ("line 55");
				
				}

				if (doRotate) {
//					var step = Time.deltaTime * 2;
//					pug.transform.Rotate = Quaternion.Lerp (startRotation, endRotation, step);
//					pug.transform.eulerAngles = new Vector3(
//						Mathf.LerpAngle(startRotation.x, 30, Time.deltaTime),
//						Mathf.LerpAngle(startRotation.y, 180, Time.deltaTime),
//						Mathf.LerpAngle(startRotation.z, 0, Time.deltaTime));
////					print ("****** the step is " + step.ToString());
//					print ("*****************rotating*****************");
//					print ("the velocity is " + rb_pug.velocity.ToString());
//					print ("the start rotation is " + startRotation.ToString ());
//					print ("the end rotation is " + endRotation.ToString ());
//					print ("the current rotation is " + pug.transform.eulerAngles);
					pug.GetChild(pug.childCount - 1).gameObject.SetActive(true);
					pug.transform.rotation = Quaternion.Euler (-10, 180, 0);
					waittoload += Time.deltaTime;

					if (pug.transform.eulerAngles.y == 180) {
//						anim_pug.Play("bark");
						anim_pug.enabled = false;
//						transform.rotation = Quaternion.Euler (-1, 0, 0);
						if (waittoload > 1.5f) {
							doRotate = false;
							startFOV = Camera.main.fieldOfView;
							zoomInFOV = 30;
							doZoom = true;
							startRotation = transform.rotation;
							endRotation = Quaternion.Euler (-1, 0, 0);
						}
					}
//					pug.transform.rotation = Quaternion.Slerp (startRotation, endRotation, Time.deltaTime * 2);
//					print ("*****************rotating*****************");
//					print ("the velocity is " + rb.velocity.ToString());
//					print ("the start rotation is " + startRotation.ToString ());
//					print ("the end rotation is " + endRotation.ToString ());
//					print ("the current rotation is " + transform.rotation);
//					if (transform.rotation == new Quaternion (0, -1.0f, 0, 0)) {
//						doRotate = false;
//						startFOV = Camera.main.fieldOfView;
//						zoomInFOV = 30;
//						doZoom = true;
//					}
				}
				if (doZoom) {
					transform.rotation = Quaternion.Slerp (startRotation, endRotation, Time.deltaTime * 2);
					Camera.main.fieldOfView = Mathf.Lerp(startFOV, zoomInFOV, Time.deltaTime * 2);
					if (Camera.main.fieldOfView < 30.5f) {
						doZoom = false;
						doMove = false;
						doRotate = false;
						SceneManager.LoadScene ("LevelComplete");
					}
				}


			}
		
	}

}
}