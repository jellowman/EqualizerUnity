using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			MapController.flipSong ();
			foreach (Vector3 spawnpoint in MapController.getSpawnPoints())
				Debug.Log(spawnpoint);
		}
	}
}
