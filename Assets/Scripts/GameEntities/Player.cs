using UnityEngine;
using System.Collections;

public class Player : Entity {

	public int secondaryDamage = 4;
	public float topSpeed = 1;
	public int Score = 0;

	private float upperBound = 9.5f;
	private float lowerBound = -9.5f;
	private float leftBound = -21.33f;
	private float rightBound = 21.33f;


	private float curSpeedX;
	private float curSpeedY;
	private float targetSpeed;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;


	void Start(){
		points = 0;
		curSpeedX = 0;
		curSpeedY = 0;
		health = 6;
		damage = 1;
		Score = 0;
		base.Start();
	}



	void Update () {
	
		//Vertical movement

		targetSpeed = topSpeed * Input.GetAxisRaw ("Vertical");
		curSpeedY = IncrementTowards (curSpeedY, targetSpeed, speed);

		if(transform.position.y + curSpeedY > upperBound){
			curSpeedY = upperBound-transform.position.y;
		}
		if(transform.position.y +curSpeedY < lowerBound){
			curSpeedY = -transform.position.y +lowerBound;
		}


		//Horizontal movement


		targetSpeed = topSpeed * Input.GetAxisRaw ("Horizontal");
		curSpeedX = IncrementTowards (curSpeedX, targetSpeed, speed);

		if(transform.position.x + curSpeedX > rightBound){
			curSpeedX = rightBound-transform.position.x;
		}
		if(transform.position.x +curSpeedX < leftBound){
			curSpeedX = -transform.position.x +leftBound;
		}


		if (Input.GetButton("Fire1") && Time.time > nextFire){
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
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
