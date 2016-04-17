using UnityEngine;
using System.Collections;

public class Enemy : BaseCharacter {
	
	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate() {
		BaseCharacter[] targets = GameObject.FindObjectsOfType<BaseCharacter> ();
		//GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Wall");

		double max = double.MaxValue;
		BaseCharacter target = null;

		foreach (BaseCharacter bc in targets) {
			if (!(CompareTag(bc.tag))) {
				double dist = Mathf.Sqrt (Mathf.Pow((bc.transform.position.x - this.transform.position.x),2) + Mathf.Pow((bc.transform.position.y - this.transform.position.y),2));
				//Debug.Log (dist);
				if (dist < max) {
					max = dist;
					target = bc;
				}
			}
		}

		if (target != null) {
			movex = target.transform.position.x - transform.position.x;
			movey = target.transform.position.y - transform.position.y;
		} 
		Vector2 temp = new Vector2 (movex, movey);
		rigidBody.velocity = temp.normalized * PlayerSpeed;

		if (movex != 0 || movey != 0) {
			lastDirection = temp;
		}

		Shoot();
	}



	// Update is called once per frame
	void Update () {
	
	}
}
