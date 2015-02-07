using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Upgrade1 : MonoBehaviour {

	public Player player;

	private Text upgradeText;
	private string upgradeString = "Primary level: ";

	void Start () {
		upgradeText = GameObject.Find ("upgrade1_text").GetComponent<Text> ();
	}

	void Update () {
		//Päivitetään tekstit
		upgradeText.text = upgradeString + player.primaryLevel;

	}

	void OnMouseDown() {
		//Debug.Log("Upgrade1 was pressed");
		player.LevelPrimary ();
	}
}
