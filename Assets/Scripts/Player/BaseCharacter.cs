using UnityEngine;
using System.Collections;

enum Shape { Cirlce, Square, Triangle};

[RequireComponent (typeof (Rigidbody2D))]
public class BaseCharacter : MonoBehaviour 
{
	public const float PlayerSpeed = 3f;
	public const float BulletSpeed = 12f;

	protected float movex = 0f;
	protected float movey = 0f;

	protected Rigidbody2D rigidBody;

	private float lastShotTime = 0f;

	/// <summary>
	/// The last direction the player was facing
	/// </summary>
	public Vector2 lastDirection;

 	void Awake() {
		rigidBody = this.GetComponent<Rigidbody2D>();
		lastDirection = new Vector2 (1, 0);
	}

	public void Shoot()
	{
		if (Time.time - lastShotTime > .15f) {
			lastShotTime = Time.time;
			Bullet bulletInstance;
			bulletInstance = Instantiate (GameState.gameState.bulletPrefab, this.transform.position, GameState.gameState.bulletPrefab.transform.rotation) as Bullet;
			bulletInstance.GetComponent<Rigidbody2D> ().velocity = lastDirection.normalized * BulletSpeed;
		}
	}
}
