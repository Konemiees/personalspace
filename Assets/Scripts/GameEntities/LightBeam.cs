using UnityEngine;
using System.Collections;

public class LightBeam : Entity {

	Player player;
	
	// Use this for initialization
	void Start (){
		
		player = GameObject.FindGameObjectsWithTag ("Player") [0].GetComponent<Player> ();
		
		speed = 18;
		endPoint = 24;
		health = 1;
		damage = player.secondaryDamage;
		paused = FindObjectOfType<Menuscript>().paused;
	}
	
	void Update () {
		
		damage = player.secondaryDamage;
		
		paused = FindObjectOfType<Menuscript>().paused;
		if (transform.position.x < endPoint) {
			move (new Vector2(speed * Time.deltaTime * 1,0));
		} else {
			die ();
		}
	}
}
