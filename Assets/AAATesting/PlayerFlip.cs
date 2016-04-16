using UnityEngine;
using System.Collections;

public class PlayerFlip : MonoBehaviour {

	GameObject player;

	public void flip() {
		Instantiate (GameState.playerblue, this.transform.position, this.transform.rotation);
	}
}
