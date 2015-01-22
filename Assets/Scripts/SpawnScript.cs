using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	
	public GameObject Meteor;
	public float minSpawnTime = 0.2f;
	public float upperBound = 9.7f;
	public float lowerBound = -9.7f;
	
	private float spawnTime;
	private float timePassed;
	private float Score;
	
	/*Testaamiseen
	private float delta;
	private bool alreadyPrint = false;
	**/
	
	
	
	void Start () {
		Score = 0;
		timePassed = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		//Testaamiseen
		//testScorer();
		
		
		
		
		
		if (timePassed == 0) {
			newSpawnTime();
		}
		
		timePassed += Time.deltaTime;
		
		if (timePassed > spawnTime) {
			//print(testScore);
			//print(timePassed);
			timePassed = 0;
			GameObject m = Instantiate(Meteor, new Vector3(24, randomCoordinate(), 0), Quaternion.identity) as GameObject;
		}
		
		
		
		
	}
	

	
	/*Testaamiseen
	private void testScorer(){
		testScore += Time.deltaTime * 40;
	}**/
	
	
	
	//Arpoo uuden spawn-ajan
	private void newSpawnTime(){
		Score = GameObject.FindGameObjectsWithTag ("Player") [0].GetComponent<Player> ().Score;
		float t = 0.0f;
		if (Score >= 200) {
			t = Random.Range (0.2f, 12 / (1 + Mathf.Log ((Score / 100), 1.3f)));
		} else {
			t = Random.Range(1.2f, 3.0f) ;
		}
		//print (t);
		spawnTime = t;
	}
	
	
	//Arpoo uuden spawn-koordinaatin Y-akselilla.
	private float randomCoordinate(){
		return Random.Range(lowerBound, upperBound);
	}
	
	
}
