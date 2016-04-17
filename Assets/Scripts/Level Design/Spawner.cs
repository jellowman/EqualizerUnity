using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public static Vector3[] spawnpoints = new Vector3[0];

	// Use this for initialization
	void Start () {
		Vector3[] newspawnpoints = new Vector3 [spawnpoints.Length+1];
		for (int i = 0; i < spawnpoints.Length; i++)
			newspawnpoints [i] = spawnpoints [i];
		newspawnpoints [spawnpoints.Length] = this.transform.position;
		spawnpoints = newspawnpoints;
	}
	
	// Update is called once per frame
	void Update () {}

}
