using UnityEngine;
using System.Collections;

public class basicParticle : Entity {

	void Start(){
		this.speed = 4;
		this.health = 10;
		this.damage = 5;
		this.points = 100;
	}

	void Update () {
	 	if (transform.position.x > endPoint) {
			move (new Vector2(speed * Time.deltaTime * -1,0));
		} else {
			die ();
		}
	}
}
