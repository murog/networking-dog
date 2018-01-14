﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		private Renderer m_renderer;
//		private float m_offset = 0f;
		private float spawnPosition = 35.0f;
		private float playerPosition;
		private int i = 1;
		private int j = 3;
		public Transform tree1;
		public Transform tree2;
		public Transform tree3;
		public Transform tree4;
		public Transform tree5;
//		GameObject[] trees = {tree1, tree2, tree3, tree4, tree5};
//		static Random rnd = new Random();
//		private int randomIndex = rnd.Next(0, trees.Length);
		private int randomIndex;
//		private Transform spawnedSidewalk;
//		private Transform s_tree;
//		private Transform s_tree2;
//		private Transform s_tree3;
//		private Transform s_tree4;


		void Start()
		{
			m_renderer = GetComponent<Renderer>();
			Transform[] trees = {tree1, tree2, tree3, tree4, tree5};
//			int index = rnd.Next(0, trees.Length);
			print (m_renderer);
			while ( i < j) {
				print (i);
				var spawnedSidewalk = Instantiate(sidewalk, new Vector3(0, 0, i * 20), Quaternion.identity);
				randomIndex = Random.Range (0, trees.Length);
				print(spawnedSidewalk.transform);
//				s_tree = trees [randomIndex];
//				s_tree.parent = spawnedSidewalk;
//				Instantiate(s_tree, new Vector3(-5, 0, i *-10), Quaternion.identity);
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
				i++;
			}
		}

		void Update()
		{	
			playerPosition = trulyMoveOrb.playerPosition;

//			print (trulyMoveOrb.playerPosition);
			if (playerPosition > spawnPosition) {
				while (i < j) {
					Instantiate(sidewalk, new Vector3(0, 0, i * 20), Quaternion.identity);
					i++;
				}
				j += 3;
				spawnPosition = playerPosition + 50;
			}
//			m_offset -= Time.deltaTime * (GlobalVariables.ScrollSpeed / m_scrollDivider);

//			m_renderer.material.mainTextureOffset = new Vector3(0, m_offset, 0);
		}

		void OnCollisionEnter(Collision other){
			if (other.gameObject.tag == "garbage") {
				Destroy (gameObject);
			}
		}
	}
}
