using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeathMenuScript : MonoBehaviour {

	private Player player;

	private Text scoreText;
	//private bool hasDied;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectsWithTag ("Player") [0].GetComponent<Player> ();
		scoreText = GameObject.Find ("death_score").GetComponent<Text> ();


	}
	
	// Update is called once per frame
	void Update () {

		scoreText.text = "Score: " + player.Score;

		if (player.died) {

		}


	}
}
