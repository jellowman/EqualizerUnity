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
			GameObject player = GameObject.Find ("Player");
			player.GetComponent<PlayerFlip> ().flip ();
		}
	}
}
