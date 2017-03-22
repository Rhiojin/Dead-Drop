using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicPlatform : platformBase {




	
	// Update is called once per frame
	void Update () {

		if(!levelscript.pause)
		{
			targetPos.x =  Mathf.SmoothStep (-range, range, Mathf.PingPong (seed + Time.time * speed, 1));
			transform.position = targetPos;
		}
	}
}
