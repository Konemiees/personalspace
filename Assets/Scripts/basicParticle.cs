using UnityEngine;
using System.Collections;

public class basicParticle : Entity {
	
	protected float endPoint = -24;
	public int points = 100;


	void Update () {
	 	if (transform.position.x > endPoint) {
			move (new Vector2(speed * Time.deltaTime * -1,0));
		} else {
			die ();
		}
	

	
	}



}
