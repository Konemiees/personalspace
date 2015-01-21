using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public float minSpawnTime = 0.2f;

	private float spawnTime;
	private float timePassed;

	//Testaamiseen
	private float testScore;
	private float delta;




	void Start () {
		testScore = 0;
		timePassed = 0;
	}
	
	// Update is called once per frame
	void Update () {

		//Testaamiseen
		testScorer();


		if (timePassed == 0) {
			newSpawnTime();
		}

		timePassed += Time.deltaTime;

		if (timePassed > spawnTime) {

		}
		
	}



	//Testaamiseen
	private void testScorer(){
		testScore += Time.deltaTime * 40;
	}

	private void newSpawnTime(){

	}

}
