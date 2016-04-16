using UnityEngine;
using System.Collections;

public class AudioFlipper : MonoBehaviour {

	public static int currentaudioplayer = 0;
	public static AudioSource[] audiosources = new AudioSource[0];
	AudioSource audiosource;

	// Use this for initialization
	void Start () {
		
		audiosource = GetComponent<AudioSource> ();
		audiosource.mute = true;

		AudioSource[] newaudiosources = new AudioSource[audiosources.Length + 1];
		for (int i = 0; i < audiosources.Length; i++)
			newaudiosources [i] = audiosources [i];
		newaudiosources [audiosources.Length] = audiosource;
		audiosources = newaudiosources;

		flip ();
	}

	public static void flip() {
		audiosources [currentaudioplayer].mute = true;
		currentaudioplayer = (currentaudioplayer + 1) % audiosources.Length;
		audiosources [currentaudioplayer].mute = false;
	}
}
