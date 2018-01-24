using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkingDog {
	public class Prefabs : MonoBehaviour {
	private static Object[] trees;
	private static Object[] random;
	private static Object[] street;
	private static Object[] construction;
	private static Object[] streetLamps;
	private static Object[] positive;
	private static Object[] negative;
	private static Object r_person;


	// Use this for initialization
	void Start () {
			trees = Resources.LoadAll("PROPS_ENVIRONMENT/trees", typeof(GameObject)) as Object[];
//			print ("the trees are");
//			foreach (var item in trees) {
//				print (item);
//			}
			random = Resources.LoadAll ("PROPS_ENVIRONMENT/random", typeof(GameObject)) as Object[];
//			print ("the random items are");
//			foreach (var item in random) {
//				print (item);
//			}
			street = Resources.LoadAll ("PROPS_ENVIRONMENT/street", typeof(GameObject)) as Object[];
//			print ("the street items are");
//			foreach (var item in street) {
//				print (item);
//			}
			construction = Resources.LoadAll ("PROPS_ENVIRONMENT/construction", typeof(GameObject)) as Object[];
			print ("the construction items are");
//			foreach (var item in construction) {
//				print (item);
//			}
			streetLamps = Resources.LoadAll ("PROPS_ENVIRONMENT/street_lamps", typeof(GameObject)) as Object[];
			positive = Resources.LoadAll ("encounters/positive", typeof(GameObject)) as Object[];

			negative = Resources.LoadAll ("encounters/negative", typeof(GameObject)) as Object[]; 
			foreach (var item in negative) {
				print (item);
			}
//			print(RandomTree ());
//			print(RandomTree());
	}
	
	// Update is called once per frame
	void Update () {

	}

	public static Object RandomTree() {
		var index = Random.Range(0, trees.Length);
//		return trees[index].name;
//		print("the random tree is");
//		print(trees[index]);
		var rando = trees [index];
		return rando;
	}

	public static Object RandomConstructionItem() {
		var index = Random.Range(0, construction.Length);
		var rando = construction [index];
		return rando;
		
	}
//
	public static Object RandomStreetItem () {
		var index = Random.Range(0, street.Length);
		var rando = street [index];
		return rando;
		
	}
	
	public static Object RandomItem () {
		var index = Random.Range(0, random.Length);
		var rando = random [index];
		return rando;

	}
	
	public static Object RandomStreetLamp() {
		var index = Random.Range(0, streetLamps.Length);
		var rando = streetLamps [index];
		return rando;	
	}

	public static Object RandomPositive() {
		var index = Random.Range(0, positive.Length);
		var rando = positive [index];
		return rando;	
	}

	public static Object RandomNegative() {
		var index = Random.Range (0, negative.Length);
		var rando = negative [index];
		return rando;
	}
	
	public static Object ReturnPositive(string name) {
			foreach (Object person in positive) {
				if (person.name == name.Substring(0, name.Length - 7)) {
					r_person = person;
				}
			}
			return r_person;
//			return null;
	}


}
}