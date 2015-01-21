using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	public int health;
	public float speed;
	public int damage;
	public int points;
	public float endPoint = -24;
	
	public void takeDamage(int hit){
		health -= hit;
		if (health <= 0){
			this.die();
		}
	}

	//Tarvii työstää ennen lisää testausta, tällä hetkellä optimoitu niin että pelaajahahmo teurastaa törmäilemällä kaikki muut.
	//Lol. T. Julius
	public void OnTriggerEnter2D(Collider2D other){
		if (this.gameObject.name == "Player") {
			print (other.gameObject.name + " Has collided with you!");				
			Destroy (other.gameObject);
		} else {
			Destroy(this.gameObject);
		}
	}
	
	protected void die(){
		Destroy (this.gameObject);
	}

	protected void move(Vector2 amount){
		transform.Translate (new Vector3 (amount.x, amount.y, 0));
	}

}
