using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_movement : MonoBehaviour 
{

	// Use this for initialization
	public GameObject targetToFollow;

	void Start () 
	{

	}

	void Update () 
	{
		gameObject.transform.position = new Vector3( targetToFollow.transform.position.x , targetToFollow.transform.position.y , -10 );
	}
}
