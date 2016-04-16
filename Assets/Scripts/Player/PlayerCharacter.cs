using UnityEngine;
using System.Collections;

public class PlayerCharacter : BaseCharacter {

	string horizontalAxis = "Horizontal_P1";
	string verticalAxis = "Vertical_P1";

	void FixedUpdate() {
		movex = Input.GetAxis (horizontalAxis);
		movey = Input.GetAxis (verticalAxis);

		rigidBody.velocity = new Vector2 (movex * Speed, movey * Speed);
	}

	/// <summary>
	/// Assign player 1 or 2
	/// </summary>
	/// <param name="playerNum">Enter 1 or 2 for the player number</param>
	public void SetPlayer(int playerNum) 
	{
		if (playerNum == 2) {
			horizontalAxis = "Horizontal_P2";
			verticalAxis = "Vertical_P2";
		} else if (playerNum == 1) {
			horizontalAxis = "Horizontal_P1";
			verticalAxis = "Vertical_P1";
		}
	}
}
