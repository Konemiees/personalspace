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
			/*if(wt < Time.time && died){
				Destroy(this.gameObject);
			}*/
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




}
