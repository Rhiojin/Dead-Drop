using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControls : MonoBehaviour {

	public Transform target;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (target)
			Follow ();
	}

	void Follow()
	{
	}
}
