using UnityEngine;
using System.Collections;

/// <summary>
/// Triangle can hurt Squares
/// Squares can hurt Circles
/// Circles can hurt Triangle;
/// </summary>
public enum Shape { Cirlce, Square, Triangle};

[RequireComponent (typeof (Rigidbody2D))]
public class BaseCharacter : MonoBehaviour 
{
	//The bulletFreqency is how often it is fired, lower number means more bullets. 
	public const float bulletFrequency = 0.2f;
	public const float PlayerSpeed = 3f;
	public const float BulletSpeed = 12f;
	private const int maxDamage = 5;

	protected float movex = 0f;
	protected float movey = 0f;

	protected Rigidbody2D rigidBody;

	private float lastShotTime = 0f;

	private int currentDamange = 1;

	public Shape currentShape; 

	/// <summary>
	/// The last direction the player was facing
	/// </summary>
	[HideInInspector]
	public Vector2 lastDirection;

 	void Awake() {
		rigidBody = this.GetComponent<Rigidbody2D>();
		lastDirection = new Vector2 (1, 0);

	}

	public void TakeDamage()
	{
		currentDamange--;
		if (currentDamange <= 0) {
			Debug.Log (currentShape.ToString() + " Died");
			if(this is PlayerCharacter)
				GameState.gameState.main.removePlayer (this.gameObject);
			if(this is Enemy)
				GameState.gameState.main.removeEnemy (this.gameObject);
		}
	}

	public void Shoot()
	{
		if (Time.time - lastShotTime > bulletFrequency) {
			lastShotTime = Time.time;
			Bullet bulletInstance;
			bulletInstance = Instantiate (GameState.gameState.bulletPrefab, this.transform.position, GameState.gameState.bulletPrefab.transform.rotation) as Bullet;
			bulletInstance.shotFrom = currentShape;
			bulletInstance.GetComponent<Rigidbody2D> ().velocity = lastDirection.normalized * BulletSpeed;
		}
	}

	/// <summary>
	/// Triangle can hurt Squares
	/// Squares can hurt Circles
	/// Circles can hurt Triangle;
	/// </summary>
	public static bool isTarget(Shape source, Shape target)
	{
		if (source == Shape.Triangle && target == Shape.Square
			|| source == Shape.Square && target == Shape.Cirlce
			|| source == Shape.Cirlce && target == Shape.Triangle)
			return true;
		return false;
	}

	public int getColor() {
		
		if (currentShape == Shape.Cirlce)
			return 0;
		else if (currentShape == Shape.Square)
			return 1;
		else
			return 2;
	}
}
