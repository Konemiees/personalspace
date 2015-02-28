using UnityEngine;
using System.Collections;

public class DeathMenuScript : MonoBehaviour {

	private Player player;
	//private bool hasDied;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectsWithTag ("Player") [0].GetComponent<Player> ();

		renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (player.died) {
			renderer.enabled = true;
		}


	}
}
