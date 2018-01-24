using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //do i need this if i have line 3
using UnityEngine.UI;

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
	private Rigidbody rb;
	public static bool positiveCollision = false;
	private bool outtaBounds = false;
	private bool outtaBoundsPos;
	public Text textKlout;
	public Text wiggle;
	private bool wigglin = false;
	public Transform pug;
//	public static GameObject[] connections;
//	public static ArrayList connections; 
	public static List<GameObject> connections = new List<GameObject>();
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
			int num = Random.Range (1, 3);
			print("the number is " + num.ToString());
			if (num % 2 == 0) {
				horizVel = 1f;
			} else {
				horizVel = -1f;
			}

	}
//	TODO: FLY AWAY BEHIND THEMSELVES,
	// Update is called once per frame
	void Update () {
//			TODO: CHECKOUT OUTTA BOUNDS AS A BOOL
			if (((transform.position.x > 5) || (transform.position.x < -5)) && !outtaBounds) {
			outtaBoundsPos = (transform.position.x > 0);
			print("yer outta bounds" + outtaBounds.ToString());
			outtaBounds = true;
			StartCoroutine(outOfBounds());
		}
			
		if (Input.GetKeyDown (moveL)) {
			if (horizVel < 5.5) {
				horizVel++;
				if (horizVel == 0) {
				horizVel++;
				}
			}
			print ("left");
		} else if (Input.GetKeyDown (moveR)) {
			if (horizVel > -5.5) {
				horizVel--;
				if (horizVel == 0) {
					horizVel--;
				}
			}	
			print ("right");
		} 
		rb.velocity = new Vector3 (horizVel, 0, 0);
		

//		GetComponent<Rigidbody>().velocity = new Vector3 (horizVel, 0, 0);
//		if ((Input.GetKeyDown (moveL)) && (laneNum > 1) && (!controlBlocked)) {
//			horizVel = -1;
////			StartCoroutine (stopSlide ());
//			laneNum -= 0.5f;
//			controlBlocked = true;
//			print ("left!");
//		} else if ((Input.GetKeyDown (moveR)) && (laneNum < 4) && (!controlBlocked)) {
//			horizVel = 1;
////			StartCoroutine (stopSlide ());
//			laneNum += 0.5f;
//			controlBlocked = true;
//			print ("right!");
//		} else {
////			horizVel = 0;
//			print ("else!!");
//		}
//		if (status == "exit") {
//			waitToLoad += Time.deltaTime;
//		}
		if (status == "exit") {
			SceneManager.LoadScene ("LevelComplete");
		} 
//		print (controlBlocked);
//		playerPosition = transform.position.z;
			
	}

	void OnCollisionEnter(Collision other)
	{	
			if (other.gameObject.tag == "lethal") {
				print ("this is lethal");
				print (other.gameObject);
				Destroy (gameObject);
			} else if (other.gameObject.tag == "klout") {
				positiveCollision = true;
				GM.kloutCount += 1;
				UpdateTextScore (GM.kloutCount);
//				A.add (connections, other.gameObject);
//				connections.Add (other.gameObject);
				GM.Network(other.gameObject.name);
				print ("the last item in list is");
				if (GM.connections.Count > 0) {
					print (connections [GM.connections.Count - 1]);
				} else {
					print ("nothing in here rn");
				}

				if (!wigglin) {
					wiggleWiggle ();
				}

			} else if (other.gameObject.tag == "exit") {
				print ("this is the exit huh");
				status = "exit";
			} else if (other.gameObject.tag == "sidewalk") {
				Physics.IgnoreCollision (other.collider, GetComponent<Collider> ());
			} else if (other.gameObject.tag == "garbage") {
				print ("its garbage");
				Destroy (other.gameObject);
				GM.kloutCount -= 5;
				if (GM.kloutCount < 0) {
					status = "exit";
				}
			}
	}

	void OnCollisionStay(Collision other) {
		if (other.gameObject.tag == "klout") {
			GM.kloutCount += 1;
//			print (GM.kloutCount);
		} 
	}

	void UpdateTextScore(int currentScore) {
			textKlout.text = string.Format ("KLOUT: {0}", currentScore);
	}
	
	IEnumerator wiggleWiggle () {
			wigglin = true;
			wiggle.transform.Rotate (0, 0, 100);
			yield return new WaitForSeconds (3.0f);
			wiggle.transform.Rotate (0, 0, -100);
			wigglin = false;
	}
			

	IEnumerator stopSlide ()
	{
		yield return new WaitForSeconds(0.3f);
		horizVel = 0;
		controlBlocked = false;
//		return;
	}

	IEnumerator outOfBounds() 
	{	
		StartCoroutine (WhereUGoing());
		yield return new WaitForSeconds (3.5f);
			if ((transform.position.x > 5 || transform.position.x < -5) && ((outtaBoundsPos == (transform.position.x > 0)))) {
				print ("hey u lost");
				wiggle.text = "hey u lost";
				status = "exit";
			} else {
				print ("ok ur cool");
				wiggle.text = "ok ur cool";
				wiggle.fontSize = 80;
				wiggle.transform.Rotate (0, 0, -150);
				status = "cool";
				outtaBounds = false;
				yield return new WaitForSeconds (0.5f);
				wiggle.text = "wiggle wiggle";
				wiggle.fontSize = 40;
				wiggle.transform.rotation = new Quaternion (0, 0, 0, 0);

			}
	}
	
	IEnumerator WhereUGoing()
	{
		wiggle.text = "where u going?";
		wiggle.transform.Rotate (0, 0, 50);
		yield return new WaitForSeconds(1.5f);
			if ((transform.position.x > 5 || transform.position.x < -5) && ((outtaBoundsPos == (transform.position.x > 0)))) {
				wiggle.text = "hey come back here";
				wiggle.transform.Rotate (0, 0, 100);
			} 
				

	}


}
}
