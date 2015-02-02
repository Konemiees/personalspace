using UnityEngine;
using System.Collections;

public class Menuscript : MonoBehaviour {

	public int paused;
	//public Texture 

	// Use this for initialization
	void Start () {
		paused = -1;
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetButtonDown ("Menu")) {


			paused = paused * -1;
			GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>().paused = paused;
			GameObject.FindGameObjectsWithTag("Background")[0].GetComponent<SpaceBackground>().paused = paused;
			for(int i = 0; i < GameObject.FindGameObjectsWithTag("Enemies").Length; i++){
				GameObject.FindGameObjectsWithTag("Enemies")[i].GetComponent<Entity>().paused = paused;
			}
			for(int i = 0; i < GameObject.FindGameObjectsWithTag("Shots").Length; i++){
				GameObject.FindGameObjectsWithTag("Shots")[i].GetComponent<Entity>().paused = paused;
			}


		}

	}


	/**void OnGui(){

		if (paused == 1) {

			GUI.DrawTexture(Rect(Screen.width*0.5-50, Screen.height*0.5+2.5f, 100, 40), pause)

		}
		
	}**/

}
