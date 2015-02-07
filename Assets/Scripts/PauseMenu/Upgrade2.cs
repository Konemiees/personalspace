using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Upgrade2 : MonoBehaviour {

	public Player player;

	private Text upgradeText;
	private string upgradeString = "Secondary level: ";

	void Start () {
		upgradeText = GameObject.Find ("upgrade2_text").GetComponent<Text> ();
	}
	
	void Update () {
		
		upgradeText.text = upgradeString + player.secondaryLevel;

	}

	void OnMouseDown() {
		//Debug.Log("Upgrade2 was pressed");
		player.LevelSecondary ();
	}
}
