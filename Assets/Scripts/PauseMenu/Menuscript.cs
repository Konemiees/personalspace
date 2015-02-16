using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menuscript : MonoBehaviour {

	public int paused;
	public Player player;
	//public Texture 

	private GameObject menuObject;
	private GameObject menuTexts;
	private Renderer menuRend;

	private GameObject temp;

	private bool[] upgradeAvail = new bool[3];

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectsWithTag ("Player") [0].GetComponent<Player> ();

		menuObject = GameObject.Find("Menu");
		menuTexts = GameObject.Find("Menutexts");
		menuRend = menuObject.renderer;

		//menuRend.enabled = false;

		paused = -1;

		Toggle ();
	}
	
	// Update is called once per frame
	void Update () {

		UpgradeCheck ();

		if (Input.GetButtonDown ("Menu")) {

			paused = paused * -1;


			for(int i = 0; i < GameObject.FindGameObjectsWithTag("Shots").Length; i++){
				GameObject.FindGameObjectsWithTag("Shots")[i].GetComponent<Entity>().paused = paused;
			}

			Toggle();
		}

		//Tsekataan jos päivitys saatavilla ja sen mukaan näytetään tai piilotetaan nappulat
		if (menuRend.enabled) {
			for (int i = 0; i < menuObject.transform.childCount; i++) {
				
				temp = menuObject.transform.GetChild(i).gameObject;
				
				if (upgradeAvail[i]) {
					temp.renderer.enabled = menuRend.enabled;
					temp.GetComponent<BoxCollider2D>().enabled = menuRend.enabled;
				} else {
					temp.renderer.enabled = false;
					temp.GetComponent<BoxCollider2D>().enabled = false;
				}
			}
		}

	}


	//Piilottaa ja näyttää menun. Disabloi myös tekstit ja nappulat, eli boxcolliderit
	public void Toggle() {

		menuRend.enabled = !menuRend.enabled;

		//Enable/disable nappulaspritet
		foreach(Renderer r in menuObject.GetComponentsInChildren<Renderer>())
			r.enabled=menuRend.enabled;
		//Enable/disable boxcolliderit
		foreach(BoxCollider2D b in menuObject.GetComponentsInChildren<BoxCollider2D>())
			b.enabled=menuRend.enabled;
		//Enable/disable tekstit
		foreach(Text t in menuTexts.GetComponentsInChildren<Text>())
			t.enabled=menuRend.enabled;

	}

	private void UpgradeCheck() {
		//Tsekataan onko päivityksiä saatavilla.
		//0=primary, 1=secondary, 2=shield

		upgradeAvail [0] = player.primaryUpgrade ();
		upgradeAvail [1] = player.secondaryUpgrade ();
		upgradeAvail [2] = player.shieldUpgrade ();

	}

	/**
	void OnGui(){

		if (paused == 1) {

			GUI.DrawTexture(Rect(Screen.width*0.5-50, Screen.height*0.5+2.5f, 100, 40), "pause");

		}
		
	}
	*/

}
