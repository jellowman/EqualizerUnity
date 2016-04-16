using UnityEngine;
using System.Collections;

public class Enemy : BaseCharacter {
	
	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate() {
		BaseCharacter[] targets = GameObject.FindObjectsOfType<BaseCharacter> ();
		GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Wall");
		double max = double.MaxValue;
		BaseCharacter target = null;
		foreach (BaseCharacter bc in targets) {
			if (!(this.CompareTag (bc.tag))) {
				double dist = Mathf.Sqrt ((bc.transform.position.x - this.transform.position.x) + (bc.transform.position.y - this.transform.position.y));
				if (dist < max) {
					max = dist;
					null = bc;
				}
			}
		}

		movex = Input.GetAxis (horizontalAxis);
		movey = Input.GetAxis (verticalAxis);

		rigidBody.velocity = new Vector2 (movex * PlayerSpeed, movey * PlayerSpeed);

		if (movex != 0 || movey != 0) {
			lastDirection = new Vector2 (movex, movey);
		}

		Shoot(lastDirection);
	}



	// Update is called once per frame
	void Update () {
	
	}
}
