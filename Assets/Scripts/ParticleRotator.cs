using UnityEngine;
using System.Collections;

public class ParticleRotator : MonoBehaviour {


	public int paused;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		print(gameObject.GetComponent<Animator> ().GetInteger ("died"));
	
		paused = FindObjectOfType<Menuscript>().paused;

		if(paused == -1){
			transform.RotateAround(transform.position, new Vector3(0, 0, 1), Time.deltaTime*10);
		}

	}
}
