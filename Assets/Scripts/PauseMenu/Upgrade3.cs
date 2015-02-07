using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Upgrade3 : MonoBehaviour {

	public Player player;

	private Text upgradeText;
	private string upgradeString = "Shield level: ";

	void Start () {
		upgradeText = GameObject.Find ("upgrade3_text").GetComponent<Text> ();
	}
	
	void Update () {
		
		upgradeText.text = upgradeString + player.shieldLevel;

	}

	void OnMouseDown() {
		Debug.Log("Upgrade3 was pressed");
		player.LevelShield ();
	}
}
