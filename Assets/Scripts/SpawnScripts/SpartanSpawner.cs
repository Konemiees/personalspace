using UnityEngine;
using System.Collections;

public class SpartanSpawner : ZigSpawnScript {


	
	// Update is called once per frame
	protected void Update () {
		
		scoreLowLimit = 2500;
		base.Update();

	}
}
