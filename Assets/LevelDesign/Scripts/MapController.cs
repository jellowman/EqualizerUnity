using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour {

	//Call every time the player object is flipped
	public static void flipSong() {
		AudioFlipper.flip ();
	} 

	public static Vector3[] getSpawnPoints() {
		return Spawner.spawnpoints;
	}
}
