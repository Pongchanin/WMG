using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    GameObject player;              //Player 1 Gameobj
    PlayerHealth playerHealth;      //Player 1 Health

    GameObject player2;             //Player 2 Gameobj
    Player2Health player2Health;    //Player 2 Gameobj
    
    Text player1HP_txt;
    Text player2HP_txt;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        player2 = GameObject.FindGameObjectWithTag("plaYer2");
        player2Health = player2.GetComponent<Player2Health>();
    }

    void Start ()
    {
        player1HP_txt = GameObject.Find("player1Health").GetComponent<Text>();
        player2HP_txt = GameObject.Find("player2Health").GetComponent<Text>();
	}
	

	void Update ()
    {
        if (playerHealth.currentHealth <= 0)
        {

        }

        player1HP_txt.text = "Health: " + playerHealth.currentHealth;
        player2HP_txt.text = "Health: " + player2Health.currentHP;
	}
}
