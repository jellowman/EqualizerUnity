using UnityEngine;
using System.Collections;

public class AudioFlipper : MonoBehaviour {

	public static int currentaudioplayer = 0;
	public static int totalaudioplayers = 0;

	int audioplayerid;
	AudioSource audiosource;

	// Use this for initialization
	void Start () {
		audiosource = GetComponent<AudioSource> ();
		audiosource.mute = true;
		audioplayerid = totalaudioplayers;
		totalaudioplayers++;
		flip ();
	}

	// Update is called once per frame
	void Update () {
		if (audioplayerid == currentaudioplayer)
			audiosource.mute = false;
		else
			audiosource.mute = true;
	}

	public static void flip() {
		currentaudioplayer = (currentaudioplayer + 1) % totalaudioplayers;
	}
}
