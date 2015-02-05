using UnityEngine;
using System.Collections;

public class Upgrade2 : MonoBehaviour {

	public Player player;

	void Update () {
		//Tsekkaus jos päivitys saatavilla, muuten nappula harmaaksi
	}

	void OnMouseDown() {
		//Debug.Log("Upgrade2 was pressed");
		player.LevelSecondary ();
	}
}
