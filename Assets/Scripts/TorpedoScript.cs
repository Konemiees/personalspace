using UnityEngine;
using System.Collections;

public class TorpedoScript : Entity {

	// Use this for initialization
	void Start (){
		speed = 8;
		endPoint = 24;
	}

	void Update () {
		if (transform.position.x < endPoint) {
			move (new Vector2(speed * Time.deltaTime * 1,0));
		} else {
			die ();
		}
	}
}
