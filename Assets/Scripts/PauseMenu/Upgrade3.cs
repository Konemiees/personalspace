using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Upgrade3 : MonoBehaviour {

	public Player player;

	private Text upgradeText;
	private string upgradeString;
	
	void Start () {
		upgradeText = GameObject.Find ("upgrade3_text").GetComponent<Text> ();
		upgradeString = "Shield level: ";
	}
	
	void Update () {
		
		upgradeText.text = upgradeString + player.shieldLevel;
		
		//Tsekkaus jos päivitys saatavilla, muuten nappula harmaaksi
	}

	void OnMouseDown() {
		Debug.Log("Upgrade3 was pressed");
		player.LevelShield ();
	}
}
