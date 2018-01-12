using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkingDog
{
	[AddComponentMenu("CUSTOM / Ground Scroll")]
	[RequireComponent(typeof(Renderer))]
	public class GroundScroll : Singleton<GroundScroll>
	{
		[SerializeField]
		private float m_scrollDivider;
//		[SerializeField]
		public Transform sidewalk;
		private Renderer m_renderer;
		private float m_offset = 0f;
		private float spawnPosition = 35.0f;
		private float playerPosition;
		private int i = 1;
		private int j = 3;

		void Start()
		{
			m_renderer = GetComponent<Renderer>();
			print (m_renderer);
			while (i < j) {
				print (i);
				Instantiate(sidewalk, new Vector3(0, 0, i * 20), Quaternion.identity);
				i++;
			}
		}

		void Update()
		{	
			playerPosition = trulyMoveOrb.playerPosition;
			print (trulyMoveOrb.playerPosition);
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
	}
}
