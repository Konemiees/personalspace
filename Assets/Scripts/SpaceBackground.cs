using UnityEngine; 
using System.Collections;

public class SpaceBackground : MonoBehaviour { 

	public float speed = 0;
	public int paused = -1;

	void Update() {
		paused = FindObjectOfType<Menuscript>().paused;
		if (paused == -1) {
			renderer.material.mainTextureOffset = new Vector2 (Time.time * speed, 0f);
		}
	}
}