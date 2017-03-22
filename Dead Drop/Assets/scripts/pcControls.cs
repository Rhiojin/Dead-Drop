using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pcControls : MonoBehaviour {

	public Rigidbody2D thisRigidbody;
	public Vector2 jumpForce;
	public Vector2 breakforce;
	public platformBase currentplatform;
	public int strength = 1;
	public levelManager levelScript;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0))
		{
			Jump ();
		}
	}

	void Jump()
	{
		thisRigidbody.AddForce (jumpForce);
	}

	void OnCollisionEnter2D(Collision2D cols)
	{
		if (cols.collider.CompareTag ("platform"))
		{
			if(levelScript.nextPlatform == null && levelScript.currentPCPlatform == null)
			{
				//gameover
				Destroy(gameObject);
			}
			else if(cols.transform.parent.name != levelScript.nextPlatform.name && levelScript.currentPCPlatform == null )
			{
				//gameover
				Destroy(gameObject);
			}
			else
			{
				if(currentplatform == null)currentplatform = cols.transform.parent.GetComponent<platformBase> ();
				if (strength >= currentplatform.hp) 
				{
					//breakthrough
					if (transform.parent != null) transform.SetParent(null);
					if (currentplatform != null) currentplatform = null;
						
					levelScript.SetNextPlatform();
					Destroy(cols.transform.parent.gameObject);

					thisRigidbody.AddForce (breakforce);
					levelScript.currentPlatformCount--;

					return;
				}
				levelScript.currentPCPlatform = cols.transform.parent.gameObject;
				currentplatform.TakeDmg (strength);
				cols.transform.position += new Vector3 (0, 0.3f, 0);
				if (transform.parent == null) transform.SetParent (cols.transform.parent);

			}

		}
	}
}
