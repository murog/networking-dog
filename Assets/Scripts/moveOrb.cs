﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOrb : MonoBehaviour {
	private Rigidbody rb;
	public KeyCode moveL;
	public KeyCode moveR;

	public float horizVel = 0;
	public int laneNum = 2;
	public string controlBlocked;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector3(horizVel, 0, 4);
		print (transform.position);

		if ((Input.GetKeyDown(moveL)) && (laneNum>1) && (controlBlocked == "n")) {
			horizVel = -2;
			StartCoroutine (stopSlide());
			laneNum -= 1;
			controlBlocked = "y";
		}

		if ((Input.GetKeyDown(moveR)) && (laneNum < 3) && (controlBlocked == "n")) {
			horizVel = 2;
			StartCoroutine(stopSlide());
			laneNum += 1;
			controlBlocked = "y";
		}


	}

	IEnumerator stopSlide() 
	{
		yield return new WaitForSeconds(0.5f);
		horizVel = 0;
		controlBlocked = "n";
		}


	}﻿