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
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();

	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Player1" && playerHealth.currentHealth <10) 
		{
			Destroy (col.gameObject);
            print("Health: " + playerHealth.currentHealth);
		}
        else if(col.gameObject.name == "Player1" && playerHealth.currentHealth > 0)
        {
            //Do nothing
            print("Health: " + playerHealth.currentHealth);
            playerHealth.currentHealth -= 10;
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



