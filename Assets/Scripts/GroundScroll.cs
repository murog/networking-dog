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
//		public Transform player;
		private Object player;
		public Transform sidewalk;
		public Transform tree1;
		public Transform tree2;
		public Transform tree3;
		public Transform tree4;
		public Transform tree5;
		private GameObject rando_tree;  

		private int randomIndex;

		private Transform spawnedSidewalk;
		private GameObject rando_lamp;
		private GameObject rando_item;
		private GameObject rando_street_item;
		private int spawnCount = 0;



		void Start()
		{
			player = Resources.Load ("player", typeof(GameObject)) as Object;
			SpawnSidewalk(0);
			SpawnSidewalk(1);
			SpawnSidewalk(2);
			SpawnSidewalk (3);

		}

		void Update()
		{	
			if (garbage.spawnable) {
				SpawnSidewalk (3);
				garbage.spawnable = false;
			}
		}



		void OnCollisionEnter(Collision other){
			if (other.gameObject.tag == "garbage") {
				Destroy (gameObject);
			}
		}

		private void SpawnSidewalk (float z_offset) {
			spawnedSidewalk = Instantiate(sidewalk, new Vector3(0, 0, z_offset * 100), Quaternion.identity);
			if (z_offset == 0) {
//				Vector3 playerSpawn = new Vector3 (spawnedSidewalk.transform.position.x, spawnedSidewalk.transform.position.y + 1, spawnedSidewalk.transform.position.z);
//				Instantiate (player, playerSpawn, Quaternion.identity);
			}
			SpawnTrees (spawnedSidewalk);
			SpawnStreetLamps (spawnedSidewalk);
			SpawnRandomItems (spawnedSidewalk);
			SpawnRandomStreetItems (spawnedSidewalk);
			spawnCount++;
			print ("the sidewalk position is");
			print(spawnedSidewalk.transform.position);
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

//		private void SpawnItems(Transform parentSidewalk, float offset, ) {
//			for (float i = offset; i < -(offset); i+= 10) {
//				
//			}
//		}


	}
}
