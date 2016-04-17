using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public Shape shotFrom;

	void OnTriggerEnter2D(Collider2D coll) {
		PlayerCharacter player = coll.gameObject.GetComponent<PlayerCharacter> ();
		if (player == null) {
			Destroy (this.gameObject);
		//same shapes cannot damage each other
		} else if(!(player.currentShape == shotFrom)) {
			player.TakeDamage();
		}
	}
}
