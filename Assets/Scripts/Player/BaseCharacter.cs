using UnityEngine;
using System.Collections;

enum Shape { Cirlce, Square, Triangle};

[RequireComponent (typeof (Rigidbody2D))]
public class BaseCharacter : MonoBehaviour 
{
	public const float Speed = 5f;
	protected float movex = 0f;
	protected float movey = 0f;

	protected Rigidbody2D rigidBody;

 	void Awake() {
		rigidBody = this.GetComponent<Rigidbody2D>();
	}

}
