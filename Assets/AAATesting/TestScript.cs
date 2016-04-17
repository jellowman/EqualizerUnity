using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

	GameObject gamemaker;
	Main main;

	// Update is called once per frame
	void Update () {

		gamemaker = GameObject.Find ("GameMaker");
		main = gamemaker.GetComponent<Main> ();
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			MapController.flipSong ();
			GameObject player = main.player;
			player.GetComponent<PlayerFlip> ().flip ();
		}

		if (Input.GetKeyDown (KeyCode.O)) {
			//main.removePlayer ();
		}
	}
}
