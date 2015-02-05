using UnityEngine;
using System.Collections;

public class Upgrade1 : MonoBehaviour {

	public Player player;

	void Update () {
		//Tsekkaus jos päivitys saatavilla, muuten nappula harmaaksi
	}

	void OnMouseDown() {
		//Debug.Log("Upgrade1 was pressed");
		player.LevelPrimary ();
	}
}
