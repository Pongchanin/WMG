using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mycharacter : MonoBehaviour {

	public float moveSpeed = 10;
	public float jumpPower = 300;
	private int jumpTime = 0;

	// Use this for initialization
	void Start () 
{

	}

	// Update is called once per frame
	void Update () 
	{
		Rigidbody2D rigid = gameObject.GetComponent< Rigidbody2D > ();

		if ( Input.GetKey(KeyCode.D))
		{
			rigid.AddForce ( new Vector2( moveSpeed , 0 ) );

		}

		else if (Input.GetKey (KeyCode.A)) 
		{
			rigid.AddForce ( new Vector2( -moveSpeed , 0 ) );

		} 

		if ( Input.GetKeyDown(KeyCode.Space))
		{
			if (jumpTime < 2) 
			{
				rigid.AddForce ( new Vector2( 0 , jumpPower ) );
				jumpPower += 1;
			}

		}
	}

	void OnCollisionEnter2D( Collision2D hitwith )
	{
		if ( hitwith.gameObject.CompareTag ("JumpReset")) 
		{
			jumpTime = 0;
		}
	}
	void OnCollisionStay2D( Collision2D hitwith )
	{

	}
	void OnCollisionExit2D( Collision2D hitwith )
	{
		print ("Our character stop to collide with " + hitwith.gameObject.name);
	}
}
