using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NetworkingDog 
{
public class UIManager : MonoBehaviour {

		public Text textScore;

	// Use this for initialization
	void Start () {
		textScore = GetComponent<Text> ();
//		textCurrentScore = textScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void UpdateTextScore(int currentScore) {
		textScore.text = string.Format ("KLOUT: {0}", currentScore);
	}

}
}