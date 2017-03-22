using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashCollector : MonoBehaviour {

	public levelManager levelScript;

	void OnCollisionEnter2D (Collision2D col) 
	{
		levelScript.currentPlatformCount--;
		Destroy(col.transform.parent.gameObject);
	}

	void OnTriggerEnter2D(Collider2D trig)
	{
		levelScript.currentPlatformCount--;
		Destroy(trig.transform.parent.gameObject);
	}
}
