using UnityEngine;
using System.Collections;

public class Spartan : Entity {  //Vaihdetaan perittäväksi basicParticle kun kuolinanimaatio on toteutettu T: Konsta

	public Transform target;
	public float targetingSpeed;
	


	void Update () {
		paused = FindObjectOfType<Menuscript>().paused;
		target = GameObject.Find ("Player").transform;
		if(transform.position.x > endPoint){
			move (new Vector2(speed * Time.deltaTime * -1,targetingSpeed * Time.deltaTime * Mathf.Sign(target.position.y - transform.position.y)));
		} else {
			die ();
		}
	}







}
