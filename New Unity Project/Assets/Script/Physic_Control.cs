using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physic_Control : MonoBehaviour 
{


	public Animator anim;
	public float moveSpeed = -10f;
	public float jumpPower = 200f;
	private int jumpTime = 0;

	public GameObject characterSprite;

		Rigidbody2D rigid2D;
		Transform characterTransform;

		// Use this for initialization
		void Start () 
		{
			rigid2D = gameObject.GetComponent< Rigidbody2D >();
			characterTransform = gameObject.GetComponent< Transform >();
		}

		// Update is called once per frame
		void Update () 
		{
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			rigid2D.AddForce (new Vector2 (-12, 0));
			characterTransform.localScale = new Vector3 (-1, 1, 1);
			anim.SetBool ("On move", true);

		} else if (Input.GetKey (KeyCode.D)|| Input.GetKey (KeyCode.RightArrow)) {
			rigid2D.AddForce (new Vector2 (12, 0));
			characterTransform.localScale = new Vector3 (1, 1, 1);
			anim.SetBool ("On move", true);
		} 
		else 
		{
			anim.SetBool ("On move", false);
		}
	
		if ( Input.GetKeyDown(KeyCode.Space))
		{
			if (jumpTime < 1) 
			{
				rigid2D.AddForce ( new Vector2( 0 , jumpPower ) );
				characterTransform.position += new Vector3 ( 0 , 0.1f , 0 );
				jumpPower += 0;
				anim.SetTrigger ("Active Jump");
				Sound_Manger.instance.PlaySound (0); 


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