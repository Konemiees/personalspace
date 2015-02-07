using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Upgrade2 : MonoBehaviour {

	public Player player;

	private Text upgradeText;
	private string upgradeString;
	
	void Start () {
		upgradeText = GameObject.Find ("upgrade2_text").GetComponent<Text> ();
		upgradeString = "Secondary level: ";
	}
	
	void Update () {
		
		upgradeText.text = upgradeString + player.secondaryLevel;
		
		//Tsekkaus jos päivitys saatavilla, muuten nappula harmaaksi
	}

	void OnMouseDown() {
		//Debug.Log("Upgrade2 was pressed");
		player.LevelSecondary ();
	}
}
