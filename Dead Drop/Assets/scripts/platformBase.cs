using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformBase : MonoBehaviour {

	public Vector3 targetPos;
	public float seed = 0;
	public int hp = 2;
	public float range = 7.5f;
	public float speed = 1.2f;
	public GameObject platform;
	public levelManager levelscript;

	public enum platformTypes
	{
		starter,
		basic
	};

	void Start () {

		levelscript = GameObject.Find("Level Manager").GetComponent<levelManager>();

		targetPos = transform.position;
		seed = Random.Range (0, 1.0f);
		speed = Random.Range (0.5f, 0.8f);
		//randomize size
	}

	public void TakeDmg(int dmg)
	{
		//TODO = do pooling
		hp -= dmg;
//		if (hp <= 0) {
//			connectedPC.SetParent (null);
//			Destroy (gameObject);
//		}
	}

}
