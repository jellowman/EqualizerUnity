using UnityEngine;
using System.Collections;

public class PlayerCharacter : BaseCharacter {

	void FixedUpdate() {
		movex = Input.GetAxis ("Horizontal");
		movey = Input.GetAxis ("Vertical");

		rigidBody.velocity = new Vector2 (movex * Speed, movey * Speed);
	}
}
