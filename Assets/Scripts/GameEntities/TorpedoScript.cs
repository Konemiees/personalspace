using UnityEngine;
using System.Collections;

public class TorpedoScript : Entity {

	// Use this for initialization
	void Start (){
		speed = 18;
		endPoint = 24;
		health = 1;
		damage = 1;
		paused = FindObjectOfType<Menuscript>().paused;
	}

	void Update () {
		paused = FindObjectOfType<Menuscript>().paused;
		if (transform.position.x < endPoint) {
			move (new Vector2(speed * Time.deltaTime * 1,0));
		} else {
			die ();
		}
	}
}
