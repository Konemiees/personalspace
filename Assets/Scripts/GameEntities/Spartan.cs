using UnityEngine;
using System.Collections;

public class Spartan : Entity {  //Vaihdetaan perittäväksi basicParticle kun kuolinanimaatio on toteutettu T: Konsta

	public Transform target;
	public float targetingSpeed;
	private float targetBefore;
	


	void Update () {
		paused = FindObjectOfType<Menuscript>().paused;
		target = GameObject.Find ("Player").transform;
		if(transform.position.x > endPoint && !FindObjectOfType<Player>().died){
			move (new Vector2(speed * Time.deltaTime * -1,Check()));
			if(wt < Time.time && died){
				Destroy(this.gameObject);
	}
		} else {
			base.die();
		}
		targetBefore = target.position.y;
	}


	private float Check(){
		float ret;
		float nextStep = targetingSpeed * Time.deltaTime * Mathf.Sign(target.position.y - transform.position.y);
		if (target.position.y == transform.position.y) {
			ret = 0;
		} else if (Mathf.Sign (target.position.y - nextStep) != Mathf.Sign (target.position.y - transform.position.y) && target.position.y == targetBefore) {
			ret = target.position.y - transform.position.y;
		} else {
			ret = nextStep;
		} return ret;
	}




	protected float wt = 0;
	protected bool died = false;
	
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



