using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Any global information that needs to be referenced accross scrips can be stored here
/// This might include things such as Current shape count, kills, time, score, etc. 
/// </summary>
public class GameState : MonoBehaviour {

	public static GameState gameState;

	[HideInInspector]
	public Main main;

	[HideInInspector]
	public UIController UI;

	public Bullet bulletPrefab;

	public float playerBulletFrequency = 0.2f;
	public float enemyBulletFrequency = 0.5f;
	public float PlayerSpeed = 3f;
	public float BulletSpeed = 12f;
	public int maxDamage = 5;
	public float invulnerableTime = 2;

	[HideInInspector]
	public int score = 0;

	[HideInInspector]
	public int killCount;

	[HideInInspector]
	public int numPlayers;

	void Awake() 
	{
		if (gameState == null) {
			DontDestroyOnLoad (transform.gameObject);
			gameState = this;
		} else {
			Destroy (this.gameObject);
		}
	}

	public void initializeSinglePlayer()
	{
		numPlayers = 1;
	}

	public void initializeMultiPlayer()
	{
		numPlayers = 2;
	}

	public void gameOver()
	{
		Application.LoadLevel("MainMenu");
		killCount = 0;
	}
}
