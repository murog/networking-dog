using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using NetworkingDog;
namespace NetworkingDog
{
	[AddComponentMenu("CUSTOM / Ground Scroll")]
//	[RequireComponent(typeof(Renderer))]
	public class GroundScroll : Singleton<GroundScroll>
	{
		[SerializeField]
		private float m_scrollDivider;
//		[SerializeField]
		public Transform sidewalk;
//		private Renderer m_renderer;
//		private float m_offset = 0f;
		private float spawnPosition = 0;
		private float playerPosition;
		private int i = 0;
		private int j = 3;
		public Transform tree1;
		public Transform tree2;
		public Transform tree3;
		public Transform tree4;
		public Transform tree5;
		private GameObject rando_tree;  
//		GameObject[] trees = {tree1, tree2, tree3, tree4, tree5};
//		static Random rnd = new Random();
//		private int randomIndex = rnd.Next(0, trees.Length);
		private int randomIndex;
//		private Transform spawnedSidewalk;
//		private Transform s_tree;
//		private Transform s_tree2;
//		private Transform s_tree3;
//		private Transform s_tree4;
		private Transform spawnedSidewalk;
		private GameObject rando_lamp;
		private GameObject rando_item;
		private GameObject rando_street_item;



		void Start()
		{
//			m_renderer = GetComponent<Renderer>();
//			Transform[] trees = {tree1, tree2, tree3, tree4, tree5};
//			int index = rnd.Next(0, trees.Length);
//			print (m_renderer);
//			rando = Prefabs.RandomTree () as GameObject;
//			print ("rando is");
//			print (rando_tree);
//			print(Prefabs.RandomTree);
//			while ( i < j) {
//				SpawnSidewalk (i);
//				i++;
//			}
//				print (i);
////				rando = new GameObject ();
////				rando = Prefabs.RandomTree () as GameObject;
////				spawnedSidewalk = Instantiate(sidewalk, new Vector3(0, 0, i * 100), Quaternion.identity);
////				randomIndex = Random.Range (0, trees.Length);
//				print(spawnedSidewalk.transform);
////				rando.transform.parent = spawnedSidewalk;
//				for (int offset = -50; offset < 50 ; offset += 5) {
//					rando_tree = Prefabs.RandomTree () as GameObject;
//					rando_tree.transform.parent = spawnedSidewalk;
//					rando_lamp = Prefabs.RandomStreetLamp () as GameObject;
//					rando_lamp.transform.parent = spawnedSidewalk;
//					rando_item = Prefabs.RandomItem () as GameObject;
//					rando_street_item = Prefabs.RandomStreetItem () as GameObject;
//					Vector3 leftPosition = new Vector3 (-5, 4, spawnedSidewalk.transform.position.z + offset);
//					Vector3 rightPosition = new Vector3 (5, 4, spawnedSidewalk.transform.position.z + offset);
////					Instantiate trees
//					(Instantiate (rando_tree, leftPosition, Quaternion.identity)).transform.parent = spawnedSidewalk;
//					(Instantiate (rando_tree, rightPosition, Quaternion.identity)).transform.parent = spawnedSidewalk;
////					Instantiate street lamps
//					(Instantiate (rando_lamp, leftPosition, Quaternion.identity)).transform.parent = spawnedSidewalk;

//					Instantiate random props
//					Instantiate construction items?



//				s_tree = trees [randomIndex];
//				s_tree.parent = spawnedSidewalk;
//				GameObject go = Instantiate(rando, new Vector3(-5, 0, -10), Quaternion.identity) as GameObject;
//				(Instantiate(rando, new Vector3(-5, 0, -10), Quaternion.identity) as GameObject).transform.parent = spawnedSidewalk;
//				go.transform.parent = spawnedSidewalk;
//				Instantiate(s_tree, new Vector3(5, 0, -10), Quaternion.identity);
//				randomIndex = Random.Range(0, trees.Length);
//				s_tree2 = trees [randomIndex];
//				s_tree2.parent = spawnedSidewalk;
//				Instantiate(s_tree, new Vector3(-5, 0, i* -5), Quaternion.identity);
//				Instantiate(s_tree, new Vector3(5, 0, -5), Quaternion.identity);
//				randomIndex = Random.Range(0, trees.Length);
//				s_tree3 = trees [randomIndex];
//				s_tree3.parent = spawnedSidewalk;
//				Instantiate(s_tree3, new Vector3(-5, 0, i * 1), Quaternion.identity);
//				Instantiate(s_tree3, new Vector3(5, 0, 0), Quaternion.identity);
//				randomIndex = Random.Range(0, trees.Length);
//				s_tree4 = trees [randomIndex];
//				s_tree4.parent = spawnedSidewalk;
//				Instantiate(s_tree3, new Vector3(-5, 0, i * 5), Quaternion.identity);
//				Instantiate(s_tree3, new Vector3(5, 0,  5), Quaternion.identity);
//				i++;
//			}
		}

		void Update()
		{	
			playerPosition = trulyMoveOrb.playerPosition;

//			print (trulyMoveOrb.playerPosition);
			if (playerPosition > spawnPosition) {
//					Instantiate(sidewalk, new Vector3(0, 0, i * 20), Quaternion.identity)
				SpawnSidewalk(((spawnPosition+50)/50)-1);
				}

//				spawnPosition = playerPosition + 50;
			}
//			m_offset -= Time.deltaTime * (GlobalVariables.ScrollSpeed / m_scrollDivider);

//			m_renderer.material.mainTextureOffset = new Vector3(0, m_offset, 0);


		void OnCollisionEnter(Collision other){
			if (other.gameObject.tag == "garbage") {
				Destroy (gameObject);
			}
		}

		private void SpawnSidewalk (float z_offset) {
			if (z_offset < 0) {
				z_offset = 0;
			}
			spawnedSidewalk = Instantiate(sidewalk, new Vector3(0, 0, z_offset * 100), Quaternion.identity);

			SpawnTrees (spawnedSidewalk);
			SpawnStreetLamps (spawnedSidewalk);
			SpawnRandomItems (spawnedSidewalk);
			SpawnRandomStreetItems (spawnedSidewalk);
			if (spawnedSidewalk.transform.position.z < 100) {
				spawnPosition = spawnedSidewalk.transform.position.z +50;

			} else {
				spawnPosition = spawnedSidewalk.transform.position.z - 50;
			}
		}

		private void SpawnTrees (Transform parentSidewalk) {
			for (int offset = -50; offset < 50; offset+= 5) {
				rando_tree = Prefabs.RandomTree () as GameObject;
//				rando_tree.transform.parent = parentSidewalk;
				Vector3 leftPosition = new Vector3 (-5, 4, spawnedSidewalk.transform.position.z + offset);
				Vector3 rightPosition = new Vector3 (5, 4, spawnedSidewalk.transform.position.z + offset);
				Quaternion leftRotation = Quaternion.Euler(0, 180,0);
				(Instantiate (rando_tree, leftPosition, leftRotation)).transform.parent = spawnedSidewalk;
				(Instantiate (rando_tree, rightPosition, Quaternion.identity)).transform.parent = spawnedSidewalk;
			}
		}

		private void SpawnStreetLamps(Transform parentSidewalk) {
			for (float offset = -47.5f; offset < 47.5; offset += 10) {
				rando_lamp = Prefabs.RandomStreetLamp() as GameObject;
				Vector3 leftPosition = new Vector3 (-5, spawnedSidewalk.transform.position.y +2, spawnedSidewalk.transform.position.z + offset);
				Vector3 rightPosition = new Vector3 (5, spawnedSidewalk.transform.position.y + 2, spawnedSidewalk.transform.position.z + offset);
				Quaternion leftRotation = Quaternion.Euler(0, 180,0);
				(Instantiate (rando_lamp, leftPosition, leftRotation)).transform.parent = spawnedSidewalk;
				(Instantiate (rando_lamp, rightPosition, Quaternion.identity)).transform.parent = spawnedSidewalk;
			}
		}
		private void SpawnRandomItems(Transform parentSidewalk) {
			for (float offset = -42.5f ; offset < 42.5f; offset += 10) {
				rando_item = Prefabs.RandomItem() as GameObject;
				Vector3 leftPosition = new Vector3 (-5, spawnedSidewalk.transform.position.y + 1.25f, spawnedSidewalk.transform.position.z + offset);
				Vector3 rightPosition = new Vector3 (5, spawnedSidewalk.transform.position.y + 1.25f, spawnedSidewalk.transform.position.z + offset);
				Quaternion leftRotation = Quaternion.Euler(0, 180,0);
				(Instantiate (rando_item, leftPosition, leftRotation)).transform.parent = spawnedSidewalk;
				(Instantiate (rando_item, rightPosition, Quaternion.identity)).transform.parent = spawnedSidewalk;
			}			
		}

		private void SpawnRandomStreetItems(Transform parentSidewalk) {
			for (float offset = -48.5f ; offset < 48.5f; offset += 10) {
				rando_street_item = Prefabs.RandomStreetItem() as GameObject;
				Vector3 leftPosition = new Vector3 (-5, spawnedSidewalk.transform.position.y + 1.25f, spawnedSidewalk.transform.position.z + offset);
				Vector3 rightPosition = new Vector3 (5, spawnedSidewalk.transform.position.y + 1.25f, spawnedSidewalk.transform.position.z + offset);
				Quaternion leftRotation = Quaternion.Euler(0, 180,0);
				(Instantiate (rando_street_item, leftPosition, leftRotation)).transform.parent = spawnedSidewalk;
				(Instantiate (rando_street_item, rightPosition, Quaternion.identity)).transform.parent = spawnedSidewalk;
			}
		}


	}
}
