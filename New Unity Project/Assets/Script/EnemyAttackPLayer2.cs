using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackPLayer2 : MonoBehaviour {

    public int attackDamage = 10;

    GameObject player;          //Player 2 Gameobj
    Player2Health playerHealth;  //Player 2 Health

    bool playerInRange;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("plaYer2");               //Gather Player 2 Data
        playerHealth = player.GetComponent<Player2Health>();                 //Get HP from Player 2

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player2" && playerHealth.currentHP < 10)
        {
            Destroy(col.gameObject);
            print("Health: " + playerHealth.currentHP);
        }
        else if (col.gameObject.name == "Player2" && playerHealth.currentHP > 0)
        {
            //Do nothing
            Destroy(col.gameObject);
            print("Health: " + playerHealth.currentHP);
            playerHealth.currentHP -= 10;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }
    void Attack()
    {


        if (playerHealth.currentHP > 0)
        {

            playerHealth.HurtPlayer(attackDamage);
        }
    }
}
