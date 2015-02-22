using UnityEngine;
using System.Collections;

public class Spartan : basicParticle {

	public Transform target;
	public float targetingSpeed;

	void Start () {
	
	}
	

	void Update () {
		paused = FindObjectOfType<Menuscript>().paused;
		
		if(transform.position.x > endPoint){
			move (new Vector2(speed * Time.deltaTime * -1,targetingSpeed * Time.deltaTime * Mathf.Sign(target.position.y - transform.position.y)));
		} else {
			die ();
		}
	}




	//Alemmat otetaan pois, kun kuolinanimaatio on implementoitu

	protected void die(){
		Destroy (this.gameObject);
	}

	public void takeDamage(int hit){
		this.health -= hit;
		if (health <= 0){
			this.die();
			GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>().Score += points;
			GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>().fragments += 1;
			//print(GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>().Score);
		}
	}
	
	//Tarvii työstää ennen lisää testausta, tällä hetkellä optimoitu niin että pelaajahahmo teurastaa törmäilemällä kaikki muut.
	//Lol. T. Julius
	public void OnTriggerEnter2D(Collider2D other){
		
		if (other.tag == "Menu") { //Menussa colliderit. Crashaa jos törmää muihin pelin juttuihin
			//Ei tehä mittää
		} else {
			Entity otherPlayer = other.GetComponent<Entity> ();
			if (otherPlayer is Spartan){
				//Debug.Log("Shots fired!");
				Spartan temp = other.GetComponent<Spartan>();
				temp.OnTriggerEnter2D(this.gameObject.GetComponent<Collider2D>());
				goto skippaus;
			}
			if (this is Player) {
				//print (other.gameObject.name + " Has collided with you!");	
				otherPlayer.takeDamage (this.damage);
			} else if (otherPlayer is Player) {
				//print (this + " Has collided with you!");
				takeDamage (otherPlayer.damage);
			} else if (otherPlayer is TorpedoScript) {
				takeDamage (otherPlayer.damage);
				otherPlayer.takeDamage (damage);
			} else if (this is TorpedoScript) {
				takeDamage (otherPlayer.damage);
				otherPlayer.takeDamage (damage);
			} else {
				takeDamage (20);
			}
		skippaus:
				;
		}
	}
}
