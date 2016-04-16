using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	Shape shotFrom;

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.GetComponent<PlayerCharacter> () == null) {
			Debug.Log ("Hit");
			Destroy (this.gameObject);
		}
	}
}
