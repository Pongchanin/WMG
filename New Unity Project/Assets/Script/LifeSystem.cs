using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour 
{
	public int maxPlayerHealth;
	public static int playerHealth;
	public const int maxHealth = 10;
	public int currentHealth = maxHealth;
	 
	private HuntCharacter huntCharacter;

	Physic_Control playerMovement;                             
	EnemyAttack playerShooting;
	bool isDead;
	bool damaged;


	void Start () 
	{
		playerHealth = maxPlayerHealth;


	}
	
	void Awak()
	{
		playerMovement = GetComponent <Physic_Control> ();
		playerShooting = GetComponentInChildren <EnemyAttack> ();
	
		currentHealth = maxHealth;
	}

	void Update () 
	{
		if (damaged) 
		{
			
		}
		if (playerHealth <= 0) 
		{
			Death ();
		}


	}

	public void HuntCharacter(int damageToGive)
	{
		playerHealth -= damageToGive;
	}

	public void FullHealth()
	{
		playerHealth = maxPlayerHealth;
	}

	public void TakeDamage(int amount)
	{

		damaged = true;
		currentHealth -= amount;
		if (currentHealth <= -10) 
		{
			currentHealth = -10;
			Debug.Log ("Dead!");
		}
		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}
	void Death ()
	{
		Destroy(gameObject);
		isDead = true;

		playerMovement.enabled = false;
		playerShooting.enabled = false;

	}   

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "My_Character") 
		{
			Destroy (col.gameObject);
		} 
	}
}
