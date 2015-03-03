using UnityEngine;
using System.Collections;

public class Aika : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > 78) {
			Application.LoadLevel ("mainMenu");
		}
	
	}
}
