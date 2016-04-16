using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour {

	private static int counter = 0;

	//Call every time the player object is flipped
	public static void flipSong() {
		AudioFlipper.flip ();
	} 

	public static void spawn(GameObject person) {
		person.transform.position = Spawner.spawnpoints [counter];
		counter = (counter + 1) % Spawner.spawnpoints.Length;
	}
}
