using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Upgrade1 : MonoBehaviour {

	public Player player;

	private Text upgradeText;
	private string upgradeString;

	void Start () {
		upgradeText = GameObject.Find ("upgrade1_text").GetComponent<Text> ();
		upgradeString = "Primary level: ";
	}

	void Update () {
		//Päivitetään tekstit
		upgradeText.text = upgradeString + player.primaryLevel;

		//Tsekkaus jos päivitys saatavilla, muuten nappula harmaaksi
	}

	void OnMouseDown() {
		//Debug.Log("Upgrade1 was pressed");
		player.LevelPrimary ();
	}
}
