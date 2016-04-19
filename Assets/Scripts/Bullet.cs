using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public BaseCharacter shotFrom;

	void Awake()
	{
		StartCoroutine (TimeOut ());
	}

	IEnumerator TimeOut() {
		yield return new WaitForSeconds (1);
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		BaseCharacter player = coll.gameObject.GetComponent<BaseCharacter> ();
		if (player == null) {
			Destroy (this.gameObject);
		//same shapes cannot damage each other
		} else if(shotFrom.currentShape != player.currentShape) {
			player.TakeDamage(shotFrom is PlayerCharacter);
			Destroy (this.gameObject);
		}
	}
}
