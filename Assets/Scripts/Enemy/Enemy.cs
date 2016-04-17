using UnityEngine;
using System.Collections;

public class Enemy : BaseCharacter {
	
	void FixedUpdate() {
		BaseCharacter[] targets = GameObject.FindObjectsOfType<BaseCharacter> ();
		GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Wall");

		double max = double.MaxValue;
		BaseCharacter target = null;

		//if true, we're stuck and need to avoid something
		bool avoid = false;

		foreach (BaseCharacter bc in targets) {
			if (this.currentShape != bc.currentShape) {
				//Calculate distance to the object
				double dist = Mathf.Sqrt (Mathf.Pow((bc.transform.position.x - this.transform.position.x),2) + Mathf.Pow((bc.transform.position.y - this.transform.position.y),2));
				//Debug.Log (dist);
				//if the object is closer, switch to it.
				if (dist < max) {
					max = dist;
					target = bc;
				}
			}
		}

		//get the x-y components of the vector to the target
		if (target != null) {
			movex = target.transform.position.x - transform.position.x;
			movey = target.transform.position.y - transform.position.y;
		} else {
			movex = 0;
			movey = 0;
		}

		Vector2 temp = rigidBody.velocity;
		//make the vector
		if (!avoid) {
			temp = new Vector2 (movex, movey);
		}
		//simple wall avoidance
		//get current vector
		float current = rigidBody.velocity.magnitude;

		bool needAvoidVector = true;
		float avoidStart = 0f;
		//check if stuck (or close enough)
		if (current < (temp.magnitude / 4)){
			//flag that we need to avoid something
			avoid = true;
			needAvoidVector = false;
			//store the start avoidance movement time
			avoidStart = Time.time;
			int direction = Random.Range (0, 4);
			if (direction == 0) {
				temp = new Vector2 (0, movey);
			} else if (direction == 1) {
				temp = new Vector2 (movex, 0);
			} else if (direction == 2) {
				temp = new Vector2 (0, -movey);
			} else {
				temp = new Vector2 (-movex, 0);
			}
		}

		//check if we've been trying to avoid for more than half a second
		if ((Time.time - avoidStart) < .5f) {
			
		} else {
			//we've been trying to dodge long enough.  Resume chase.
			avoid = false;
		}

		//use (unit vector * player speed) so the enemies don't outrun the player
		rigidBody.velocity = temp.normalized * PlayerSpeed;

		if (movex != 0 || movey != 0) {
			lastDirection = temp;
		}

		//fire
		Shoot();
	}

}
