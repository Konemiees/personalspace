using UnityEngine;
using System.Collections;

public class Spartan : basicParticle {

	public Transform target;


	void Start () {
	
	}
	

	void Update () {
		paused = FindObjectOfType<Menuscript>().paused;
		
		if(transform.position.x > endPoint){
			
		} else {
			die ();
		}
	}
}
