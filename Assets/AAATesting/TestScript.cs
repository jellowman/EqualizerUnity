using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			
			MapController.flipSong ();
			GameObject player = GameObject.Find ("Player");
			player.GetComponent<PlayerFlip> ().flip ();
		}

		if (Input.GetKeyDown (KeyCode.O)) {

			GameObject player = GameObject.Find ("Player");
			MapController.spawn (player);
		}
	}
}
