using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public Shape shotFrom;

	void OnTriggerEnter2D(Collider2D coll) {
		BaseCharacter player = coll.gameObject.GetComponent<BaseCharacter> ();
		if (player == null) {
			Destroy (this.gameObject);
		//same shapes cannot damage each other
		} else if(shotFrom != player.currentShape) {
			player.TakeDamage();
			Destroy (this.gameObject);
		}
	}
}
