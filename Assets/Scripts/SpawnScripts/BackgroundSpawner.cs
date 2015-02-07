using UnityEngine;
using System.Collections;

public class BackgroundSpawner : SpawnScript {

	public GameObject Object2;
	public GameObject Object3;
	public GameObject Object4;
	public GameObject Object5;
	public GameObject Object6;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected void Update () {
	
		paused = FindObjectOfType<Menuscript>().paused;
		
		//Testaamiseen
		//testScorer();
		
		
		
		if (paused == -1) {
			
			if (timePassed == 0) {
				newSpawnTime ();
			}

			GameObject BackObject = chooseRandomObject();

			timePassed += Time.deltaTime;
			
			if (timePassed > spawnTime) {
				timePassed = 0;
				GameObject m = Instantiate (BackObject, new Vector3 (24, randomCoordinate (), 9), Quaternion.identity) as GameObject;
			}
			
		}

	}

	protected void newSpawnTime(){

	float t = Random.Range(15.0f, 20.0f) ;
	
	spawnTime = t;

	}

	private GameObject chooseRandomObject(){

		int r = Random.Range (0, 5);
		GameObject ret = Object;

		if (r == 0) {
			ret = Object;
		}
		if (r == 1) {
			ret = Object2;
		}
		if (r == 2) {
			ret = Object3;
		}
		if (r == 3) {
			ret = Object4;
		}
		if (r == 4) {
			ret = Object5;
		}
		if (r == 5) {
			ret = Object6;
		}

		return ret;
	}

}
