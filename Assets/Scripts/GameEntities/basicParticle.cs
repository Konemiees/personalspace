using UnityEngine;
using System.Collections;

public class basicParticle : Entity {

	void Start(){
		this.speed = 6;
		this.health = 3;
		this.damage = 5;
		this.points = 100;
		paused = FindObjectOfType<Menuscript>().paused;
	}

	void Update () {
		paused = FindObjectOfType<Menuscript>().paused;
	 	if (transform.position.x > endPoint) {
		//	transform.RotateAround(transform.position, new Vector3(0, 0, 1), Time.deltaTime);
			move (new Vector2(speed * Time.deltaTime * -1,0));
		} else {
			die ();
		}
	}
}
