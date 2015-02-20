using UnityEngine; 
using System.Collections;

public class SpaceBackground: MonoBehaviour { 

	public float speed = 0;
	public int paused = -1;
	private float delta = 0;
	private float fixedPoint;

	void Update() {
		paused = FindObjectOfType<Menuscript>().paused;
		if (paused == -1) {
			fixedPoint += Time.deltaTime;
			renderer.material.mainTextureOffset = new Vector2 (fixedPoint * speed, 0f);
		} 
	}
}