using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	public int health = 6;
	public float speed = 0.8f;
	public int damage = 1;
	
	public void takeDamage(int hit){
		health -= hit;
		if (health <= 0){
			this.die();
		}
	}

	protected void die(){

	}

	protected void move(Vector2 amount){
		transform.Translate (new Vector3 (amount.x, amount.y, 0));
	}

}
