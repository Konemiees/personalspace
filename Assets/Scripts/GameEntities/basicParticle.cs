using UnityEngine;
using System.Collections;

public class basicParticle : Entity {

	protected float wt = 0;
	protected bool died = false;

	void Start(){

		this.health = 3;
		this.damage = 1;
		this.points = 100;
		paused = FindObjectOfType<Menuscript>().paused;
	}

	void Update () {
		paused = FindObjectOfType<Menuscript>().paused;
	 	if (transform.position.x > endPoint && !FindObjectOfType<Player>().died) {
		//	transform.RotateAround(transform.position, new Vector3(0, 0, 1), Time.deltaTime);
			move (new Vector2(speed * Time.deltaTime * -1,0));
			if(wt < Time.time && died){

				Destroy(this.gameObject);
			}
		} else {
			base.die ();
		}
	}

	protected void die(){
		this.GetComponent<Animator> ().SetInteger ("died", 1);
		wt = Time.time+0.5f;
		died = true;
	//	Destroy (transform.GetChild (0));
	}




	//Alemmat kopioitu, koska muuten käytetään väärää kuolintapaa T: Konsta

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
		
		if (other.tag == "Menu" || died == true) { //Menussa colliderit. Crashaa jos törmää muihin pelin juttuihin
			//Ei tehä mittää
		} else {
			Entity otherPlayer = other.GetComponent<Entity> ();				
			 if (otherPlayer is Player) {
				Debug.Log("Shots fired_1");
				//print (this + " Has collided with you!");
				otherPlayer.takeDamage (this.damage);
				takeDamage (otherPlayer.damage);
			} else if (otherPlayer is TorpedoScript) {
				Debug.Log("Shots fired_2");
				takeDamage (otherPlayer.damage);
				otherPlayer.takeDamage (damage);
			
			} else if (otherPlayer is LightBeam) {
				Debug.Log("Shots fired_3");
				takeDamage (otherPlayer.damage);
				otherPlayer.takeDamage (damage);
			} else {
				takeDamage (20);
			}
	
		}
	}

}
