using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Any global information that needs to be referenced accross scrips can be stored here
/// This might include things such as Current shape count, kills, time, score, etc. 
/// </summary>
public class GameState : MonoBehaviour {

	public static GameState gameState;

	public Main main;

	public GameObject playerblue;
	public GameObject playergreen;
	public GameObject playerred;

	public GameObject AI;

	public int maxEnemyCount = 10;

	public Bullet bulletPrefab;

	[HideInInspector]
	public int killCount;

	[HideInInspector]
	public int numPlayers;

	void Awake() 
	{
		DontDestroyOnLoad (transform.gameObject);
		main = GameObject.FindObjectOfType<Main> ();
		gameState = this;
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
