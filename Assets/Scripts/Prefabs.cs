using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkingDog {
	public class Prefabs : MonoBehaviour {
	private static Object[] trees;


	// Use this for initialization
	void Start () {
			trees = Resources.LoadAll("PROPS_ENVIRONMENT/trees", typeof(GameObject)) as Object[];
			foreach (var item in trees) {
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
		print("the random tree is");
//		print(trees[index]);
		var rando = trees [index];
		return rando;
	}

}
}