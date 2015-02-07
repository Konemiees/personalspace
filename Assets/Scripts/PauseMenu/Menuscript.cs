﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menuscript : MonoBehaviour {

	public int paused;
	//public Texture 

	private GameObject menuObject;
	private GameObject menuTexts;
	private Renderer menuRend;

	// Use this for initialization
	void Start () {

		menuObject = GameObject.Find("Menu");
		menuTexts = GameObject.Find("Menutexts");
		menuRend = menuObject.renderer;

		paused = -1;

		MenuTexts();

		Toggle ();
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetButtonDown ("Menu")) {

			//Pitää vielä disabloida ampuminen menun ollessa auki

			paused = paused * -1;


			for(int i = 0; i < GameObject.FindGameObjectsWithTag("Shots").Length; i++){
				GameObject.FindGameObjectsWithTag("Shots")[i].GetComponent<Entity>().paused = paused;
			}

			Toggle();
		}

	}


	//Piilottaa ja näyttää menun. Disabloi myös nappulat, eli boxcolliderit
	public void Toggle() {

		//Enable/disable nappulaspritet
		menuRend.enabled = !menuRend.enabled;
		foreach(Renderer r in menuObject.GetComponentsInChildren<Renderer>())
			r.enabled=menuRend.enabled;
		//Enable/disable boxcolliderit
		foreach(BoxCollider2D b in menuObject.GetComponentsInChildren<BoxCollider2D>())
			b.enabled=menuRend.enabled;
		//Enable/disable tekstit
		foreach(Text t in menuTexts.GetComponentsInChildren<Text>())
			t.enabled=menuRend.enabled;


	}

	public void MenuTexts() {
		GUI.depth = -3;
		GUI.Label(new Rect(0, 0, 15, 15), "Primary weapon");
	
	}

	/**
	void OnGui(){

		if (paused == 1) {

			GUI.DrawTexture(Rect(Screen.width*0.5-50, Screen.height*0.5+2.5f, 100, 40), "pause");

		}
		
	}
	*/

}
