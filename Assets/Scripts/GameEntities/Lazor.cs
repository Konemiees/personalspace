using UnityEngine;
using System.Collections;

public class Lazor : Entity {

	// Use this for initialization
	void Start () {
		this.damage = 20;
		this.health = 1000;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other){
		
		if (other.tag == "Menu") { //Menussa colliderit. Crashaa jos törmää muihin pelin juttuihin
			//Ei tehä mittää
		} else {
			Entity otherPlayer = other.GetComponent<Entity> ();
			otherPlayer.takeDamage(damage);
		}
	}
}
