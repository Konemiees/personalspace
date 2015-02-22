using UnityEngine;
using System.Collections;

public class ZigSpawnScript : SpawnScript {
	
	protected int scoreLowLimit = 1000;



	// Update is called once per frame
	protected void Update () {

		paused = FindObjectOfType<Menuscript>().paused;
		if (paused == -1) {

			if (GameObject.FindGameObjectsWithTag ("Player") [0].GetComponent<Player> ().Score >= scoreLowLimit) {
				if (timePassed == 0) {
					newSpawnTime ();
				}
		
				timePassed += Time.deltaTime;
		
				if (timePassed > spawnTime) {
					timePassed = 0;
					GameObject m = Instantiate (Object, new Vector3 (24, randomCoordinate (), 0), Quaternion.identity) as GameObject;
				}
			}
		
		}
		
		
		
	}

	protected void newSpawnTime(){
		Score = GameObject.FindGameObjectsWithTag ("Player") [0].GetComponent<Player> ().Score;
		float t;
		if (this is SpartanSpawner) {
			t = Random.Range (1.4f, 1.4f + (6 / (Mathf.Log ((Score / 100), 10))));
		} else {
			t = Random.Range (0.4f,(6 / (Mathf.Log ((Score / 100), 10))));
		}
		spawnTime = t;

	}

}
