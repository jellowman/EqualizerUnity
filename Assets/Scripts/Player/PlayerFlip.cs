﻿using UnityEngine;
using System.Collections;

public class PlayerFlip : MonoBehaviour {

	int currentcolor = 0;
	GameObject[] colors;

	// Use this for initialization
	void Start () {

		int numcolors = 3;
		colors = new GameObject[numcolors];
		for (int i = 0; i < numcolors; i++) {
			colors [i] = this.transform.GetChild (i).gameObject;
			colors [i].SetActive (false);
		}

		flip ();
	
	}

	public void flip() {

		colors [currentcolor].SetActive (false);
		currentcolor = (currentcolor+1)%colors.Length;
		colors [currentcolor].SetActive (true);

	}
}