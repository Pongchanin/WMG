using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public int attackDamage = 10;

	GameObject player;                          
	PlayerHealth playerHealth;                  
                   
	bool playerInRange;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("player");
		playerHealth = player.GetComponent <PlayerHealth> ();

	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Player1") 
		{
			Destroy (col.gameObject);
		}
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject == player)
		{
			playerInRange = true;
		}
	}


	void OnTriggerExit2D (Collider2D other)
	{
		if(other.gameObject == player)
		{
			playerInRange = false;
		}
	}
	void Attack ()
	{


	if(playerHealth.currentHealth > 0)
		{

			playerHealth.TakeDamage (attackDamage);
		}
	}

}



