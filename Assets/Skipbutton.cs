using UnityEngine;
using System.Collections;

public class Skipbutton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		OnGUI ();
		
	}

	void OnGUI(){
		//Here if the player hit the button Start will trigger an action
		if(GUI.Button(new Rect(8*Screen.width/9, 10*Screen.height/11, 100, 25), "Skip Intro")){
			//Here we call the method who will call the level named "LevelName"
			Application.LoadLevel("MainMenu");
		}
	}
}
