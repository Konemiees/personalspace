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

	private float upperBound = 9.5f;
	private float lowerBound = -9.5f;
	private float leftBound = -17.33f;
	private float rightBound = 17.33f;


	private float curSpeedX;
	private float curSpeedY;
	private float targetSpeed;

	public bool died;
	private float fireWT;

	public GameObject shot;
	public GameObject shot2;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire = 0;


	public float fireRate2 = 5.5f;
	private float nextFire2;
	private float fireStop;
	public float beamLength = .5f;
	private bool fired;
	public float interval = .5f;
	private float loadingGun;


	public int fragments;

	protected float wt = 0;

	public int primaryLevel = 0;
	public int secondaryLevel = 0;
	public int shieldLevel = 0;

	private Text healthText;
	private Text secondaryReady;
	private Text upgradeAvailText;

	private Score highscore;

	void Start(){
		points = 0;
		curSpeedX = 0;
		curSpeedY = 0;
		health = 100;
		maxHealth = health;
		damage = baseDamage;
		Score = 0;
		fragments = 0;
		fired = false;

		died = false;


		healthText = GameObject.Find ("health_text").GetComponent<Text> ();
		secondaryReady = GameObject.Find ("secondary_ready").GetComponent<Text> ();
		upgradeAvailText = GameObject.Find ("upgrade_available").GetComponent<Text> ();



		highscore = GameObject.Find ("Scoreobject").GetComponent<Score> ();


		//base.Start();
		

	}



	void Update () {

		if (died) {
			this.GetComponent<Animator> ().SetInteger ("died", 1);
		}

		if (paused == -1) {
			fireWT += Time.deltaTime;
		}


		damage = baseDamage + (primaryLevel*.5f);
		//secondaryDamage = secondaryBaseDamage + secondaryLevel;


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


		if (Input.GetButtonDown("Fire1") && fireWT > nextFire && paused != 1 && !died && !fired){
			nextFire = fireWT + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play();

		}


		if ((Input.GetButtonDown("Fire2") && fireWT > nextFire2 && paused != 1 && !died) || (fired && !died)){
			if(!fired){
				GameObject.FindGameObjectWithTag("lazorAnim").GetComponent<Animator>().SetInteger ("beamShot", 1);
				fired = true;
				loadingGun = fireWT + interval;
				fireStop = fireWT + beamLength + interval + .165f*secondaryLevel;
			}else if(loadingGun < fireWT){
				Instantiate(shot2, new Vector2(shotSpawn.position.x +24.6f, shotSpawn.position.y), shotSpawn.rotation);
				loadingGun = fireWT + 10;
			}else if( fireStop < fireWT){
				nextFire2 = fireWT + fireRate2;
				if(nextFire2 < 1)
					nextFire2 = 1;
				GameObject.FindGameObjectWithTag("lazorAnim").GetComponent<Animator>().SetInteger ("beamShot", 0);
				Destroy(GameObject.FindGameObjectWithTag("laazoor"));
				fired = false;
			}

		}

		healthText.text = "Health: "+ Mathf.FloorToInt(health);

		if (fireWT > nextFire2) {
			secondaryReady.enabled = true;
		} else {
			secondaryReady.enabled = false;		
		}

		if (primaryUpgrade() || secondaryUpgrade() || shieldUpgrade()) {
			upgradeAvailText.enabled = true;
		} else {
			upgradeAvailText.enabled = false;
		}

		move (new Vector2 (curSpeedX, curSpeedY));

		highscore.highscore = Score;

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
