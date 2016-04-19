using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public GameObject gameOverText;

    public Text score;
    public Text highScore;

	private float numCircles { get { return (float)GameState.gameState.UI.numCircles; }}
	private float numSquares { get { return (float)GameState.gameState.UI.numSquares; }}
	private float numTriangles { get { return (float)GameState.gameState.UI.numTriangles; }}
	private float maxNumShapes { get { return (float)GameState.gameState.UI.maxNumShapes; }}
	private float winPercentage { get { return GameState.gameState.winPercentage; }} 


	void Awake()
	{
		gameOverText.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
        if (numCircles / maxNumShapes >= winPercentage || numTriangles / maxNumShapes >= winPercentage || numSquares / maxNumShapes >= winPercentage) {
            if(!GameState.gameState.gameOver) {
                EndGame();
            }
        }
        else
            GameState.gameState.gameOver = false;
	}

	public void EndGame()
	{
        GameState.gameState.gameOver = true;
        if (GameState.gameState.score > GameState.highScore) {
            GameState.highScore = GameState.gameState.score;
        }
		try {
        score.text = GameState.gameState.score.ToString();
        highScore.text = GameState.highScore.ToString();
		} catch (System.Exception e) { }
		gameOverText.SetActive (true);
	}

	public void Restart()
	{
        Reset();
		GameState.gameState.score = 0;
		Application.LoadLevel (Application.loadedLevelName);
	}

	public void ReturnToMainMenu()
	{
        Reset();
		GameState.gameState.score = 0;
		Application.LoadLevel ("MainMenu");
	}

    public void Reset()
    {
        AudioFlipper.audiosources = new AudioSource[0];
		AudioFlipper.currentaudioplayer = 0;
		Spawner.spawnpoints = new Vector3[0];
    }
}
