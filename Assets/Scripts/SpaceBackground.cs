using UnityEngine; 
using System.Collections;

public class SpaceBackground : MonoBehaviour { 

	public float speed = 0;

	void Update() {
		renderer.material.mainTextureOffset = new Vector2 (Time.time * speed, 0f);
	}
}