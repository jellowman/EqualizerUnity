using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text score;

	void Update()
	{
		score.text = GameState.gameState.score.ToString ();
	}
}
