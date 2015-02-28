using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : Entity {

	//Sama kuin health
	private float maxHealth;

	public int secondaryDamage;
	public float topSpeed = 1;
	public int Score = 0;
	private int baseDamage = 1;
	private int secondaryBaseDamage = 1;

	private float upperBound = 9.5f;
	private float lowerBound = -9.5f;
	private float leftBound = -21.33f;
	private float rightBound = 21.33f;


	private float curSpeedX;
	private float curSpeedY;
	private float targetSpeed;

	public bool died;

	public GameObject shot;
	public GameObject shot2;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire = 0;

	public float fireRate2;
	private float nextFire2 = 0;

	public int fragments;

	public int primaryLevel = 0;
	public int secondaryLevel = 0;
	public int shieldLevel = 0;

	private Text healthText;
	private Text secondaryReady;

	void Start(){
		points = 0;
		curSpeedX = 0;
		curSpeedY = 0;
		health = 6;
		maxHealth = health;
		damage = baseDamage;
		Score = 0;
		fragments = 0;

		died = false;
		

		healthText = GameObject.Find ("health_text").GetComponent<Text> ();
		secondaryReady = GameObject.Find ("secondary_ready").GetComponent<Text> ();
		
//		upgradeText.enabled = false;

		//base.Start();
		

	}



	void Update () {


		damage = baseDamage + (primaryLevel-1)/3;
		secondaryDamage = secondaryBaseDamage + secondaryLevel;


		paused = FindObjectOfType<Menuscript> ().paused;
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


		if (Input.GetButton("Fire1") && Time.time > nextFire && paused != 1 && !died){
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play();

		}
		
		if (Input.GetButton("Fire2") && Time.time > nextFire2 && paused != 1 && !died){
			nextFire2 = Time.time + fireRate2;
			Instantiate(shot2, shotSpawn.position, shotSpawn.rotation);
		}

		healthText.text = "Health: "+ Mathf.FloorToInt(health/maxHealth*100);

		if (Time.time > nextFire2) {
			secondaryReady.enabled = true;
		} else {
			secondaryReady.enabled = false;		
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

	//Push button, get levels
	public void LevelPrimary() {
		fragments -= 20 + primaryLevel;
		primaryLevel += 1;
	}
	public void LevelSecondary() {
		fragments -= 20 + secondaryLevel;
		secondaryLevel += 1;
	}
	public void LevelShield() {
		fragments -= 20 + shieldLevel;
		shieldLevel += 1;
	}


	//Tarkistus jos upgradea saatavilla. Pitää luultavasti vielä viilailla paljonko fragmentteja tarvitaan millekin levulle.
	//Tällä hetkellä jokainen levu lisää tarvittavien fragmenttien määrää yhdellä
	//Samat ylemmille metodeille
	public bool primaryUpgrade() {
		if (fragments >= 20 + primaryLevel) {
			return true;
		} else {
			return false;
		}
	}
	public bool secondaryUpgrade() {
		if (fragments >= 20 + secondaryLevel) {
			return true;
		} else {
			return false;
		}
	}
	public bool shieldUpgrade() {
		if (fragments >= 20 + shieldLevel) {
			return true;
		} else {
			return false;
		}
	}
}
