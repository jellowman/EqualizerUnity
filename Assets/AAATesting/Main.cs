using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public GameObject player;
	public GameObject greenenemy;
	public GameObject redenemy;
	public GameObject blueenemy;
	public UIController ui;

	//TODO: Remove
	public GameObject uiobject;

	public int maxenemies;
	//Blue, Red, Green
	public int[] colorcount;

	// Use this for initialization
	void Start () {

		//TODO: Getobjects from gamestate
		ui = uiobject.GetComponent<UIController>();
		//player = GameState.gameState.getPlayer ();
		//enemy = GameState.gameState.getEnemy ();
		//ui = GameState.gameState.getUi();

		colorcount = new int[3];
		for (int i = 0; i < colorcount.Length; i++)
			colorcount [i] = 0;
		player = Instantiate (player);

		GameObject newenemy;
		for (int i = 0; i < maxenemies - 2; i+=3) {
			MapController.spawn (addEnemy (0));
			MapController.spawn (addEnemy (1));
			MapController.spawn (addEnemy (2));
		}

		spawnEnemies ();
	
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
			if (random < spawnrates [0])
				newenemy = addEnemy (0);
			else if (spawnrates [0] <= random && random <= spawnrates [1]) 
				newenemy = addEnemy(1);
			else 
				newenemy = addEnemy(2);

			totalenemies = colorcount [0] + colorcount [1] + colorcount [2];
			MapController.spawn (newenemy);
			checkLose ();
		}
	}

	private GameObject addEnemy(int i) {

		Debug.Log ("Adding Enemy");

		colorcount [i]++;
		GameObject newenemy;

		if (i == 0) {
			newenemy = Instantiate (blueenemy);
			ui.setNumCircles (colorcount [0]);
		} else if (i == 1) {
			newenemy = Instantiate (redenemy);
			ui.setNumSquares (colorcount [1]);
		} else {
			newenemy = Instantiate (greenenemy);
			ui.setNumTriangles (colorcount [2]);
		}

		return newenemy;

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
