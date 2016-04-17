﻿using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public GameObject player;
	public GameObject enemy;

	public int maxenemies;
	public ArrayList enemies;

	// Use this for initialization
	void Start () {

		//TODO: Getobjects from gamestate
		//player = GameState.gameState.getPlayer ();
		//enemy = GameState.gameState.getEnemy ();

		enemies = new ArrayList ();
		player = Instantiate (player);
	
	}
	
	// Update is called once per frame
	void Update () {

		//While there aren't enough enemies, spawn more
		spawnEnemies ();


	}
		
	private void spawnEnemies() {

		while (enemies.Count < maxenemies) {
			GameObject newenemy = Instantiate (enemy);
			enemies.Add (newenemy);
			MapController.spawn (newenemy);
		}
	}

	public void spawnPlayer() {
		MapController.spawn (player);
	}
}
