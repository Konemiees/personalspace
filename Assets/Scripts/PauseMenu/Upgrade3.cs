using UnityEngine;
using System.Collections;

public class Upgrade3 : MonoBehaviour {

	public Player player;

	void Update () {
		//Tsekkaus jos päivitys saatavilla, muuten nappula harmaaksi
	}

	void OnMouseDown() {
		Debug.Log("Upgrade3 was pressed");
		player.LevelShield ();
	}
}
