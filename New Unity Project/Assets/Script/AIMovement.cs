using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour 
{
	public Animator anim;
	public int moveSpeed;
	private Vector3 moveDirection;
	public int Direction;

	Transform characterTransform;

	void Start()
	{
		Direction = -1;
		characterTransform = gameObject.GetComponent< Transform >();
	}

	void Update()
	{
		Walk ();
	}

	void Walk()
	{
		if (Direction == 1) 
		{
			transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
			characterTransform.localScale = new Vector3 (-1, 1, 1);
			anim.SetBool ("On move", true);
		} 
		else
		{
			transform.Translate (Vector3.left * Time.deltaTime * moveSpeed);
			characterTransform.localScale = new Vector3 (1, 1, 1);
			anim.SetBool ("On move", true);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Monster") 
		{
			Direction = Direction * -1;
		}
	}
}