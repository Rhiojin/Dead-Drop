using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour {

	public Vector3 startSpawn = new Vector3(0,1.5f,0);
	public float spawnDelta = 7;
	public GameObject platformPrefab;

	public GameObject currentPCPlatform;
	public GameObject nextPlatform;

	public int maxPlatforms = 13;
	public int currentPlatformCount = 0;
	int index = 1;
	public string stringIndex;

	public bool pause = false;

	void Awake () {
		InitPlatform();
		
	}
	
	// Update is called once per frame
	void Update () {
		MakePlatforms ();
	}

	public void Pause()
	{
		if(pause)
		{
			
			Time.timeScale = 1;
		}
		else{
			Time.timeScale = 0;
		}
		pause = !pause;
	}

	void InitPlatform()
	{
		platformBase pb = Instantiate (platformPrefab, startSpawn,Quaternion.identity).GetComponent<platformBase>();
		pb.name = index.ToString();
		pb.speed = Random.Range (0.7f, 0.9f);

		startSpawn.y -= spawnDelta;
		currentPlatformCount++;
		index++;
//		nextPlatform = pb.gameObject;

	}


	void MakePlatforms()
	{
		if (currentPlatformCount < maxPlatforms) 
		{
			platformBase pb = Instantiate (platformPrefab, startSpawn,Quaternion.identity).GetComponent<platformBase>();
			pb.name = index.ToString();
			pb.speed = Random.Range (0.7f, 0.9f);

			startSpawn.y -= spawnDelta;
			currentPlatformCount++;
			index++;

		}
	}

	public void SetNextPlatform()
	{
		int i = int.Parse(nextPlatform.name);
		i++;
		stringIndex = i.ToString();
		nextPlatform = GameObject.Find(stringIndex);
//		currentPCPlatform = _currentPCPlatform;
	}

	public void QuickRestart()
	{
		SceneManager.LoadScene(0);
	}


}
