using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class SmoothFollow : MonoBehaviour
	{
		[SerializeField]
		private Transform target;

		[SerializeField]
		private float height = 5.0f;

		[SerializeField]
		private float heightDamping;

		float wantedHeight;
		float currentHeight;
		Vector3 targetPos;

		// Use this for initialization
		void Start() { 
			targetPos = transform.position;
		}

		// Update is called once per frame
		void LateUpdate()
		{
			// Early out if we don't have a target
			if (!target)
				return;

			wantedHeight = target.position.y + height;


			// Damp the height
			targetPos.y = Mathf.Lerp(transform.position.y, wantedHeight, heightDamping * Time.deltaTime);

//			targetPos.y = currentHeight;
			transform.position = targetPos;

		}
	}
}