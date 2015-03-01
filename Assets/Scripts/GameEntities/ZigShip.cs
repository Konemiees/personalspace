
using System.Collections;
using UnityEngine;

public class ZigShip : Entity{ //Vaihdetaan perittäväksi basicParticle kun kuolinanimaatio on toteutettu T: Konsta

	protected float lowerBound;
	protected int dir = 1;
	protected float upperBound;
	public float speedUpDown = 6;

	protected void Start(){
		this.speed = 4;
		upperBound = transform.position.y + 4;
		lowerBound = transform.position.y - 4;
		//base.Start();
	}

	void Update () {

		paused = FindObjectOfType<Menuscript>().paused;

		if (transform.position.x > endPoint && !FindObjectOfType<Player>().died) {
			move (new Vector2(speed * Time.deltaTime * -1,speed * Time.deltaTime * dir));
			if(transform.position.y + speed * Time.deltaTime *dir > upperBound || transform.position.y +speed * Time.deltaTime *dir < lowerBound){
				dir = dir*(-1);
			}
			if(wt < Time.time && died){
				Destroy(this.gameObject);
			}

		} else {
			base.die ();
		}
	}


	protected float wt = 0;
	protected bool died = false;

protected void die(){
	this.GetComponent<Animator> ().SetInteger ("die", 1);
	wt = Time.time+0.5f;
	died = true;
	//	Destroy (transform.GetChild (0));
}




//Alemmat kopioitu, koska muuten käytetään väärää kuolintapaa T: Konsta

public void takeDamage(float hit){
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
			otherPlayer.takeDamage (this.damage);
			takeDamage (20);
		} else if (otherPlayer is TorpedoScript) {
			//Debug.Log("Shots fired_2");
			takeDamage (otherPlayer.damage);
			otherPlayer.takeDamage (damage);
			print("osui");
			
		} else if (otherPlayer is LightBeam) {
			//Debug.Log("Shots fired_3");
			takeDamage (otherPlayer.damage);
			otherPlayer.takeDamage (damage);
		} else {
			takeDamage (20);
		}
		
	}
}

}


