using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntCharacter : MonoBehaviour 
	{
		public int damageToGive;

		void OnCollisionEnter2D(Collision2D other)
		{
			if(other.gameObject.tag == "Character")
			{
				other.gameObject.GetComponent<Health>().HurtPlayer(damageToGive);
			}
		}
	}
