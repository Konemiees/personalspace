//Deathscreenin tekstien ja inputtien piilotus ja näyttö kun kuolema

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DeathMenuScript : MonoBehaviour {

	private Player player;

	//private Text[] deathTexts;

	private List<Text> deathTexts = new List<Text> ();
	private List<GameObject> deathButtons = new List<GameObject> ();


	private GameObject deathHSInput;
	private GameObject deathMenu;

	//private bool hasDied;

	// Use this for initialization
	void Start () {

		deathTexts.Add (GameObject.Find ("death_score").GetComponent<Text> ());
		deathTexts.Add (GameObject.Find ("death_text").GetComponent<Text> ());
		deathTexts.Add (GameObject.Find ("highscore_entertext").GetComponent<Text> ());

		deathButtons.Add (GameObject.Find("highscore_button"));
		deathButtons.Add (GameObject.Find("death_mainmenu"));
		deathButtons.Add (GameObject.Find("death_newgame"));
		deathButtons.Add (GameObject.Find("death_highscores"));

		deathHSInput = GameObject.Find("highscore_text");

		deathMenu = GameObject.Find("deathmenu");
		//scoreText = GameObject.Find ("death_score").GetComponent<Text> ();
		//scoreText = GameObject.Find ("death_score").GetComponent<Text> ();

		player = GameObject.FindGameObjectsWithTag ("Player") [0].GetComponent<Player> ();

		foreach(Text t in deathTexts)
			t.enabled=false;

		foreach (GameObject g in deathButtons)
			g.SetActive (false);


		deathHSInput.SetActive(false);


	}
	
	// Update is called once per frame
	void Update () {

		deathTexts[0].text = "Score: " + player.Score;

		if (player.died) {
			foreach(Text t in deathTexts)
				t.enabled=true;
			foreach (GameObject g in deathButtons)
				g.SetActive (true);
			deathHSInput.SetActive(true);
		}


	}
}
