using UnityEngine;
using System.Collections;

enum Shape { Cirlce, Square, Triangle};

[RequireComponent (typeof (Rigidbody2D))]
public class BaseCharacter : MonoBehaviour 
{
	public const float PlayerSpeed = 1.5f;
	public const float BulletSpeed = 20f;

	protected float movex = 0f;
	protected float movey = 0f;

	protected Rigidbody2D rigidBody;

 	void Awake() {
		rigidBody = this.GetComponent<Rigidbody2D>();
	}

	public void Shoot(Vector2 direction)
	{
		Bullet bulletInstance;
		bulletInstance = Instantiate (GameState.gameState.bulletPrefab, this.transform.position, GameState.gameState.bulletPrefab.transform.rotation) as Bullet;
		bulletInstance.GetComponent<Rigidbody2D>().velocity = direction.normalized * BulletSpeed;
	}
}
