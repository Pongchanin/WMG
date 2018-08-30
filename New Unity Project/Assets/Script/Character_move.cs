using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_move : MonoBehaviour 
{

	Transform characterTransform;

	// Use this for initialization
	void Start () 
	{
		characterTransform = gameObject.GetComponent< Transform >();    
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.D)) 
		{
			print ("Move Right.");
			characterTransform.position += new Vector3 (0.1f, 0, 0);
			characterTransform.localScale = new Vector3 ( 1f , 1 , 1 );
		}
		else if( Input.GetKey(KeyCode.A))
		{
			print("Move Left.");
			characterTransform.position += new Vector3 ( -0.1f , 0 , 0 );
			characterTransform.localScale = new Vector3 ( -1f , 1 , 1 );
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			print ("Move Down.");
			characterTransform.position += new Vector3 ( 0 , -0.1f , 0 );
		}
		else if( Input.GetKey(KeyCode.W))
		{
			print("Move Up.");
			characterTransform.position += new Vector3 ( 0 , 0.1f , 0 );
		}



	}
}


