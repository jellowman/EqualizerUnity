using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public GameObject gameOverText;

	private float numCircles { get { return (float)GameState.gameState.UI.numCircles; }}
	private float numSquares { get { return (float)GameState.gameState.UI.numSquares; }}
	private float numTriangles { get { return (float)GameState.gameState.UI.numTriangles; }}
	private float maxNumShapes { get { return (float)GameState.gameState.UI.maxNumShapes; }}
	private float winPercentage { get { return GameState.gameState.winPercentage; }} 

	// Update is called once per frame
	void Update () {
		if (numCircles / maxNumShapes >= winPercentage || numTriangles / maxNumShapes >= winPercentage || numSquares / maxNumShapes >= winPercentage)
			EndGame ();
	}

	public void EndGame()
	{
		AudioFlipper.audiosources = new AudioSource[0];
		AudioFlipper.currentaudioplayer = 0;
		Spawner.spawnpoints = new Vector3[0];
		gameOverText.SetActive (true);
	}

	public void Restart()
	{
		GameState.gameState.score = 0;
		Application.LoadLevel (Application.loadedLevelName);
	}

	public void ReturnToMainMenu()
	{
		GameState.gameState.score = 0;
		Application.LoadLevel ("MainMenu");
	}
}
