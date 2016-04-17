using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public GameObject player;
	public GameObject greenenemy;
	public GameObject redenemy;
	public GameObject blueenemy;
	public UIController ui;

	public int maxenemies;
	//Blue, Red, Green
	public int[] colorcount;

	// Use this for initialization
	void Start () {

		//TODO: Getobjects from gamestate
		//player = GameState.gameState.getPlayer ();
		//enemy = GameState.gameState.getEnemy ();
		//ui = GameState.gameState.getUi();

		colorcount = new int[3];
		player = Instantiate (player);

		GameObject newenemy;
		for (int i = 0; i < maxenemies - 2; i+=3) {
			colorcount [0]++;
			newenemy = Instantiate (blueenemy);
			MapController.spawn (newenemy);
			colorcount [1]++;
			newenemy = Instantiate (redenemy);
			MapController.spawn (newenemy);
			colorcount [2]++;
			newenemy = Instantiate (greenenemy);
			MapController.spawn (newenemy);
		}

		spawnEnemies ();
	
	}
	
	// Update is called once per frame
	void Update () {

		//While there aren't enough enemies, spawn more


	}
		
	private void spawnEnemies() {

		int totalenemies = colorcount [0] + colorcount [1] + colorcount [2];
		while (totalenemies < maxenemies) {

			float[] spawnrates = new float[2];

			if (totalenemies != 0) {
				spawnrates [0] = ((float)colorcount [0]) / totalenemies;
				spawnrates [1] = ((float)colorcount [1]) / totalenemies + spawnrates [0];
			} else {
				spawnrates [0] = 0.33333f;
				spawnrates [1] = 0.66666f;
			}

			float random = Random.value;
			Debug.Log (Random.value);

			GameObject newenemy;
			if (random < spawnrates [0]) {
				colorcount[0]++;
				newenemy = Instantiate (blueenemy);
			} else if (spawnrates [0] <= random && random <= spawnrates [1]) {
				colorcount [1]++;
				newenemy = Instantiate (redenemy);
			} else {
				colorcount [2]++;
				newenemy = Instantiate (greenenemy);
			}

			totalenemies = colorcount [0] + colorcount [1] + colorcount [2];
			MapController.spawn (newenemy);
			checkLose ();
		}
	}

	private void spawnPlayer() {
		MapController.spawn (player);
	}

	public void removeEnemy(GameObject enemy) {
		//TODO: Reimplement these lines
		int inversecolor = 0;
		//int inversecolor = enemy.GetComponent<Enemy> ().Shape;
		colorcount[2 - inversecolor]--;
		Destroy (enemy);
		spawnEnemies ();
	}

	public void removePlayer(GameObject player) {
		spawnPlayer ();
	}

	private void checkLose() {
		if (colorcount [0] == maxenemies || colorcount [1] == maxenemies || colorcount [2] == maxenemies)
			Debug.Log ("GameOver");
	}
}
