using UnityEngine;
using System.Collections;

public class Player : Entity {

	private int primaryDamage;
	public int secondaryDamage = 4;
	public float topSpeed = 1;

	private float upperBound = 9.5f;
	private float lowerBound = -9.5f;
	private float leftBound = -21.33f;
	private float rightBound = 21.33f;


	private float curSpeedX;
	private float curSpeedY;
	private float targetSpeed;


	void Start(){
		primaryDamage = damage;
		curSpeedX = 0;
		curSpeedY = 0;
	}


	// Update is called once per frame
	void Update () {
	
	//Vertical movement

		if (Input.GetAxisRaw ("Vertical") >= 0) {
						targetSpeed = topSpeed * Input.GetAxisRaw ("Vertical");
						curSpeedY = IncrementTowards (curSpeedY, targetSpeed, speed);
		} else if (transform.position.y > lowerBound && Input.GetAxisRaw ("Vertical") <= 0) {
						targetSpeed = topSpeed * Input.GetAxisRaw ("Vertical");
						curSpeedY = IncrementTowards (curSpeedY, targetSpeed, speed);

		} if(transform.position.y + curSpeedY > upperBound){
			curSpeedY = upperBound-transform.position.y;
		}
		if(transform.position.y +curSpeedY < lowerBound){
			curSpeedY = -transform.position.y +lowerBound;
		}


		//Horizontal movement

		if (Input.GetAxisRaw ("Horizontal") >= 0) {
			targetSpeed = topSpeed * Input.GetAxisRaw ("Horizontal");
			curSpeedX = IncrementTowards (curSpeedX, targetSpeed, speed);
		} else if (transform.position.y > lowerBound && Input.GetAxisRaw ("Horizontal") <= 0) {
			targetSpeed = topSpeed * Input.GetAxisRaw ("Horizontal");
			curSpeedX = IncrementTowards (curSpeedX, targetSpeed, speed);
			
		} if(transform.position.x + curSpeedX > rightBound){
			curSpeedX = rightBound-transform.position.x;
		}
		if(transform.position.x +curSpeedX < leftBound){
			curSpeedX = -transform.position.x +leftBound;
		}




		move (new Vector2 (curSpeedX, curSpeedY));

	}
	


	private float IncrementTowards(float n, float target, float a){
		if(n == target){
			return n;
		}
		else{
			float dir = Mathf.Sign(target-n);
			n+=a*Time.deltaTime*dir;
			return(dir == Mathf.Sign(target-n))? n: target;
		}
	}
}
