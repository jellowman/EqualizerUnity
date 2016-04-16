using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	Shape shotFrom;

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.GetComponent<PlayerCharacter> () == null) {
			Destroy (this.gameObject);
		}
	}
}
