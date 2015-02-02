using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	
	public GameObject Object;
	public float minSpawnTime = 0.2f;
	public float upperBound = 9.7f;
	public float lowerBound = -9.7f;
	
	protected float spawnTime;
	protected float timePassed;
	protected float Score;

	protected int paused;
	
	/*Testaamiseen
	private float delta;
	private bool alreadyPrint = false;
	**/
	
	
	
	void Start () {
		Score = 0;
		timePassed = 0;
		paused = FindObjectOfType<Menuscript> ().paused;
		
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
		
			timePassed += Time.deltaTime;
		
			if (timePassed > spawnTime) {
				timePassed = 0;
				GameObject m = Instantiate (Object, new Vector3 (24, randomCoordinate (), 0), Quaternion.identity) as GameObject;
			}
		
		}
		
		
	}
	

	
	/*Testaamiseen
	private void testScorer(){
		testScore += Time.deltaTime * 40;
	}**/
	
	
	
	//Arpoo uuden spawn-ajan
	protected void newSpawnTime(){
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
	protected float randomCoordinate(){
		return Random.Range(lowerBound, upperBound);
	}
	
	
}
